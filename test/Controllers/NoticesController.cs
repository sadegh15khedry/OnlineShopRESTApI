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
    public class NoticesController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public NoticesController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Notices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notice>>> GetNotices()
        {
            return await _context.Notices.ToListAsync();
        }

        // GET: api/Notices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notice>> GetNotice(int id)
        {
            var notice = await _context.Notices.FindAsync(id);

            if (notice == null)
            {
                return NotFound();
            }

            return notice;
        }


        [HttpGet("[action]/{productId}")]
        public async Task<ActionResult<Like>> GetNoticesByProductId(int productId)
        {
            var likes = await _context.Notices.Where(s => s.NoticeProductId == productId).ToListAsync();

            if (likes == null)
            {
                return NotFound();
            }

            return Ok(likes);
        }

        [HttpGet("[action]/{userId}")]
        public async Task<ActionResult<Like>> GetNoticesByUserId(int userId)
        {
            var likes = await _context.Notices.Where(s => s.NoticeUserId == userId).ToListAsync();

            if (likes == null)
            {
                return NotFound();
            }

            return Ok(likes);
        }


        // PUT: api/Notices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotice(int id,[FromForm] Notice notice)
        {
            if (id != notice.NoticeId)
            {
                return BadRequest();
            }

            _context.Entry(notice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Notice>> PostNotice([FromForm] Notice notice)
        {
            var isUserIdValid = Int32.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var user = await _context.Users.FindAsync(userId);
            var product = await _context.Products.FindAsync(notice.NoticeProductId);
            if (user == null)
            {
                return Unauthorized("user not valid");
            }
            if (product == null)
            {
                return NotFound("product not found");
            }
            if (user.UserId != notice.NoticeUserId)
            {
                BadRequest("bad request");
            }

            _context.Notices.Add(notice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotice", new { id = notice.NoticeId }, notice);
        }


        // DELETE: api/Notices/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteNotice(int id)
        {
            var isUserIdValid = Int32.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var user = await _context.Users.FindAsync(userId);
            var notice = await _context.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }
            if (user.UserId != notice.NoticeUserId)
            {
                BadRequest("bad request");
            }
            _context.Notices.Remove(notice);
            await _context.SaveChangesAsync();

            return Ok("notice deleted");
        }

        private bool NoticeExists(int id)
        {
            return _context.Notices.Any(e => e.NoticeId == id);
        }
    }
}
