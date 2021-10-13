using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Data;
using test.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using AuthenticationPlugin;
using System.Security.Claims;

namespace test.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ShopDbContext _dbCotext;
        private IConfiguration _configuration;
        private readonly AuthService _auth;


        public UsersController(ShopDbContext dbCotext, IConfiguration configuration)
        {
            _configuration = configuration;
            _auth = new AuthService(_configuration);
            _dbCotext = dbCotext;
        }

        // GET: api/<UsersController1>
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_dbCotext.Users);
        }

        // GET api/<UsersController1>/5
        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            var myUser = _dbCotext.Users.Find(id);
            if (myUser == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(myUser);
            }
        }

        // POST api/<UsersController1>
        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {

            //ckecking email and username to see if already exists
            var userWithSameEmail = _dbCotext.Users.Where(u => u.Email == user.Email)
                .SingleOrDefault();
            var userWithSameUsrname = _dbCotext.Users.Where(u => u.UserName == user.UserName)
               .SingleOrDefault();
            if (userWithSameEmail != null)
            {
                return BadRequest("user with this email already exists");
            }
            else if (userWithSameUsrname != null)
            {
                return BadRequest("user with this username already exists");
            }
            var userObj = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Password = SecurePasswordHasherHelper.Hash(user.Password),
                Phone = user.Phone,
                Address = user.Address,
                Role = "user"
            };
            _dbCotext.Users.Add(userObj);
            _dbCotext.SaveChanges();
            return StatusCode(201, "user created");


        }
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var userEmail = _dbCotext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userEmail == null)
            {
                return NotFound();
            }
            if (!SecurePasswordHasherHelper.Verify(user.Password, userEmail.Password))
            {
                return Unauthorized();
            }
            var claims = new[]
{
            new Claim(JwtRegisteredClaimNames.Email, userEmail.Email),
            new Claim(ClaimTypes.Email, userEmail.Email),
            new Claim(ClaimTypes.Role, userEmail.Role),
            };

            var token = _auth.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user_id = userEmail.Id,
                user_role = userEmail.Role
            });

        }

        // PUT api/<UsersController1>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            var myUser = _dbCotext.Users.Find(id);
            if (myUser == null)
            {
                return NotFound("no found");
            }
            else
            {
                myUser.FirstName = user.FirstName;
                myUser.LastName = user.LastName;
                myUser.UserName = user.UserName;
                myUser.Address = user.Address;

                _dbCotext.SaveChanges();
                return Ok("updated");
            }

        }

        // DELETE api/<UsersController1>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles ="admin")]
        public IActionResult Delete(int id)
        {
            var myUser = _dbCotext.Users.Find(id);
            if (myUser == null)
            {
                return NotFound("no found");
            }
            else
            {
                _dbCotext.Users.Remove(myUser);
                _dbCotext.SaveChanges();
                return Ok("deleted");
            }
        }

    }
}
