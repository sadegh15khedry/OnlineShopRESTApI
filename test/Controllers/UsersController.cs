using AuthenticationPlugin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using test.Data;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ShopDbContext _context;
        private IConfiguration _configuration;
        private readonly AuthService _auth;


        public UsersController(ShopDbContext dbCotext, IConfiguration configuration)
        {
            _configuration = configuration;
            _auth = new AuthService(_configuration);
            _context = dbCotext;
        }

        // GET: api/<UsersController1>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET api/<UsersController1>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("user not found");
            }
            else
            {
                return Ok(user);
            }
        }



        // POST api/<UsersController1>/login
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginUser([FromForm] string userEmail, [FromForm] string userPassword)
        {
            var myUser = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == userEmail);
            if (myUser == null)
            {
                return NotFound("user not found");
            }
            if (SecurePasswordHasherHelper.Verify(userPassword, myUser.UserPassword) == false)
            {
                return Unauthorized("wrong password");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, myUser.UserEmail),
                new Claim(ClaimTypes.Email, myUser.UserEmail),
                new Claim(ClaimTypes.Role, myUser.UserRole),
                new Claim(ClaimTypes.NameIdentifier, myUser.UserId.ToString()),
            };

            var token = _auth.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user_id = myUser.UserId,
                user_role = myUser.UserRole,
            });

        }

        // PUT api/<UsersController1>/AddPhoto/5
        [HttpPut("[action]")]
        [Authorize]
        public async Task<IActionResult> AddPhotoUser([FromForm] IFormFile photo)
        {
            int userId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            var myUser = await _context.Users.FindAsync(userId);
            if (myUser == null)
            {
                return NotFound("not found");
            }

            else if (photo != null)
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot/img", guid + ".jpg");
                var fileStream = new FileStream(filePath, FileMode.Create);
                await photo.CopyToAsync(fileStream);
                myUser.ImageUrl = filePath.Remove(0, 7);
                await _context.SaveChangesAsync();
                return Ok("updated");
            }
            else
            {
                return BadRequest("not a valid image");
            }
        }


        // PUT api/<UsersController1>/RemovePhoto/5
        [HttpPut("[action]")]
        [Authorize]
        public async Task<IActionResult> RemovePhotoUser()
        {
            int userId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            var myUser = await _context.Users.FindAsync(userId);

            if (myUser == null)
            {
                return NotFound("not found");
            }

            else if (myUser != null)
            {
                myUser.ImageUrl = "/img\\default_profile_pic.jpg";
                await _context.SaveChangesAsync();
                return Ok("updated");
            }
            else
            {
                return BadRequest("not valid");
            }
        }


        // PUT api/<UsersController1>/update/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromForm] User user)
        {
            if (user == null)
            {
                return BadRequest("user object is null");
            }

            int userId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            //var userEntity = await _context.Users.FindAsync(userId);

            if (user.UserId != userId)
            {
                Unauthorized("you are not allowed to update this user");
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(UserExists(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            await _context.SaveChangesAsync();
            return Ok("updated");
        }


        // POST api/<UsersController1>/register
        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterUser([FromForm] User user)
        {
            //ckecking email and username to see if already exists
            var userWithSameEmail = await _context.Users.Where(u => u.UserEmail == user.UserEmail).FirstOrDefaultAsync();
            if (userWithSameEmail != null)
            {
                return BadRequest("user with this email already exists");
            }

            user.ImageUrl = "/img\\default_profile_pic.jpg";
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }


        // DELETE api/<UsersController1>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var myUser = await _context.Users.FindAsync(id);
            if (myUser == null)
            {
                return NotFound("not found");
            }
            else
            {
                _context.Users.Remove(myUser);
                await _context.SaveChangesAsync();
                return Ok("deleted");
            }
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        //public static string SubjectId(this ClaimsPrincipal user) { return user?.Claims?.FirstOrDefault(c => c.Type.Equals("sub", StringComparison.OrdinalIgnoreCase))?.Value; }

    }
}