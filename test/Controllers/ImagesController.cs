using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using test.Data;

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public ImagesController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }


        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage([FromForm] Image image)
        {
           if(image == null)
            {
                return BadRequest("not a valid image");
            }
            else if (image != null)
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot/img", guid + ".jpg");
                var fileStream = new FileStream(filePath, FileMode.Create);
                await image.ImageImage.CopyToAsync(fileStream);
                
                image.ImageUrl = filePath.Remove(0, 7);
                image.ImageImage = null;

                _context.Images.Add(image);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetImage", new { id = image.ImageId }, image);
            }

            else
            {
                return BadRequest("not a valid image");
            }

            
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return Ok("removed");
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.ImageId == id);
        }
    }
}
