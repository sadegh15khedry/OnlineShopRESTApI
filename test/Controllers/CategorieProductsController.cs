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
    public class CategorieProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public CategorieProductsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/CategorieProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieProduct>>> GetCategorieProducts()
        {
            return await _context.CategorieProducts.ToListAsync();
        }

        // GET: api/CategorieProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieProduct>> GetCategorieProduct(int id)
        {
            var categorieProduct = await _context.CategorieProducts.FindAsync(id);
           
            if (categorieProduct == null)
            {
                return NotFound();
            }

            return categorieProduct;
        }


        [HttpGet("[action]/{productId}")]
        public async Task<ActionResult<CategorieProduct>> GetCategorieProductByProductId(int productId)
        {
            var categorieProducts = await _context.CategorieProducts.Where(s => s.CategorieProductProductId == productId).ToListAsync();

            if (categorieProducts == null)
            {
                return NotFound();
            }

            return Ok(categorieProducts);
        }

        [HttpGet("[action]/{categorieId}")]
        public async Task<ActionResult<CategorieProduct>> GetCategorieProductByCategorieId(int categorieId)
        {
            var categorieProducts = await _context.CategorieProducts.Where(s => s.CategorieProductCategorieId == categorieId).ToListAsync();

            if (categorieProducts == null)
            {
                return NotFound();
            }

            return Ok(categorieProducts);
        }

        // PUT: api/CategorieProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieProduct(int id,[FromForm] CategorieProduct categorieProduct)
        {
            if (id != categorieProduct.CategorieProductId)
            {
                return BadRequest();
            }

            _context.Entry(categorieProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("catgorieProduct updated");
        }

        // POST: api/CategorieProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategorieProduct>> PostCategorieProduct([FromForm] CategorieProduct categorieProduct)
        {

            _context.CategorieProducts.Add(categorieProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieProduct", new { id = categorieProduct.CategorieProductId }, categorieProduct);
        }

        // DELETE: api/CategorieProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorieProduct(int id)
        {
            var categorieProduct = await _context.CategorieProducts.FindAsync(id);
            if (categorieProduct == null)
            {
                return NotFound();
            }

            _context.CategorieProducts.Remove(categorieProduct);
            await _context.SaveChangesAsync();

            return Ok("catgorieProduct deleted");
        }

        private bool CategorieProductExists(int id)
        {
            return _context.CategorieProducts.Any(e => e.CategorieProductId == id);
        }
    }
}
