using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using test.Data;

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public ReviewsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // GET: api/Reviews/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Review>> GetReviewByProductId(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("product not found");
            }

            var reviews = await _context.Reviews.Where(s => s.ReviewProductId == product.ProductId).ToArrayAsync();

            return Ok(reviews);
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutReview(int id, [FromForm] Review review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest("not a valid request");
            }
            var isUserIdValid = Int32.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            //var myReview = await _context.Reviews.FindAsync(id);
            var myUser = await _context.Users.FindAsync(userId);
            var product = await _context.Products.Where(s => s.ProductId == review.ReviewProductId).ToArrayAsync();
            

            if (product == null)
            {
                return NotFound("product not found");
            }
            else if (review.ReviewUserId != myUser.UserId)
            {
                return BadRequest("userid not valid");
            }


            _context.Entry(review).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("review updated");
        }



        // POST: api/Reviews
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Review>> PostReview([FromForm] Review review)
        {

            var isUserIdValid = Int32.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var myUser = await _context.Users.FindAsync(userId);
            var myProduct = await _context.Products.FindAsync(review.ReviewProductId);

            if (myUser == null)
            {
                return NotFound("user not found");
            }
            else if (myProduct == null)
            {
                return NotFound("product not found");
            }

            review.ReviewUserId = myUser.UserId;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.ReviewId }, review);
        }



        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var isUserIdValid = Int32.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var myUser = await _context.Users.FindAsync(userId);
            var review = await _context.Reviews.FindAsync(id);

            if (myUser.UserId != review.ReviewUserId)
                return Unauthorized("you are not allowed to delete this review");

            else if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return Ok("removed");
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
