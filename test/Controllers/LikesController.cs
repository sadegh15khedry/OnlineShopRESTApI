using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using test.Data;

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public LikesController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
        {
            return await _context.Likes.ToListAsync();
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Like>> GetLike(int id)
        {
            var like = await _context.Likes.FindAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }


        [HttpGet("[action]/{productId}")]
        public async Task<ActionResult<Like>> GetLikesByProductId(int productId)
        {
            var likes = await _context.Likes.Where(s => s.LikeProductId == productId).ToListAsync();

            if (likes == null)
            {
                return NotFound();
            }

            return Ok(likes);
        }

        [HttpGet("[action]/{userId}")]
        public async Task<ActionResult<Like>> GetLikesByUserId(int userId)
        {
            var likes = await _context.Likes.Where(s => s.LikeUserId == userId).ToListAsync();

            if (likes == null)
            {
                return NotFound();
            }

            return Ok(likes);
        }

        // PUT: api/Likes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLike(int id,[FromForm] Like like)
        {
            if (id != like.LikeId)
            {
                return BadRequest();
            }

            _context.Entry(like).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("like updated");
        }

        // POST: api/Likes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Like>> PostLike([FromForm] Like like)
        {
            var isUserIdValid = Int32.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var user = await _context.Users.FindAsync(userId);
            var product = await _context.Products.FindAsync(like.LikeProductId);
            if (user == null)
            {
                return Unauthorized("user not valid");
            }
            if(product == null)
            {
                return NotFound("product not found");
            }
            if(user.UserId != like.LikeUserId)
            {
                BadRequest("bad request");
            }

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLike", new { id = like.LikeId }, like);
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLike(int id)
        {
            var isUserIdValid = Int32.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var user = await _context.Users.FindAsync(userId);
            var like = await _context.Likes.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }
            if(user.UserId != like.LikeUserId)
            {
                Unauthorized("you are not allowed to delete this like");
            }

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();

            return Ok("like deleted");
        }

        private bool LikeExists(int id)
        {
            return _context.Likes.Any(e => e.LikeId == id);
        }
    }
}
