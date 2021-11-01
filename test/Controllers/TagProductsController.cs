using System;
using System.Collections.Generic;
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
    public class TagProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public TagProductsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/TagProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagProduct>>> GetTagProduct()
        {
            return await _context.TagProducts.ToListAsync();
        }

        // GET: api/TagProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagProduct>> GetTagProduct(int id)
        {
            var tagProduct = await _context.TagProducts.FindAsync(id);

            if (tagProduct == null)
            {
                return NotFound();
            }

            return tagProduct;
        }

        [HttpGet("[action]/{productId}")]
        public async Task<ActionResult<IEnumerable<Option>>> GetTagProductByProductId(int productId)
        {
            var option = await _context.TagProducts.Where(s => s.TagProductProductId == productId).ToListAsync();
            if (option == null)
                return NotFound("option not found");

            return Ok(option);
        }

        

        // PUT: api/TagProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagProduct(int id,[FromForm] TagProduct tagProduct)
        {
            if (id != tagProduct.TagProductId)
            {
                return BadRequest();
            }

            _context.Entry(tagProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("tagProduct updated");
        }

        // POST: api/TagProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagProduct>> PostTagProduct([FromForm] TagProduct tagProduct)
        {
            var product = await _context.Products.Where(s => s.ProductId == tagProduct.TagProductProductId).FirstOrDefaultAsync();
            var tag = await _context.Tags.Where(s => s.TagId == tagProduct.TagProductTagId).FirstOrDefaultAsync();
            
            if (tag == null)
                return BadRequest("tag not found");
            if(product == null)
                return BadRequest("product not found");

            _context.TagProducts.Add(tagProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagProduct", new { id = tagProduct.TagProductId }, tagProduct);
        }

        // DELETE: api/TagProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagProduct(int id)
        {
            var tagProduct = await _context.TagProducts.FindAsync(id);
            if (tagProduct == null)
            {
                return NotFound();
            }

            _context.TagProducts.Remove(tagProduct);
            await _context.SaveChangesAsync();

            return Ok("tagProduct deleted");
        }

        private bool TagProductExists(int id)
        {
            return _context.TagProducts.Any(e => e.TagProductId == id);
        }
    }
}
