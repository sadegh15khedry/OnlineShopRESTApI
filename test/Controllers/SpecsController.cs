using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using test.Data;
using test.Models;

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public SpecsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Specs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spec>>> GetSpec()
        {
            return await _context.Specs.ToListAsync();
        }

        // GET: api/Specs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spec>> GetSpec(int id)
        {
            var spec = await _context.Specs.FindAsync(id);

            if (spec == null)
            {
                return NotFound();
            }
            return spec;
        }


        // GET: api/Specs/5
        [HttpGet("[action]/{productId}")]
        public async Task<ActionResult<Spec>> GetSpecByProductId(int productId)
        {
            var specs = await _context.Specs.Where(s => s.SpecProductId == productId).ToListAsync();

            if (specs == null)
            {
                return NotFound();
            }

            return Ok(specs);
        }

        // PUT: api/Specs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpec(int id, [FromForm] Spec spec)
        {
            if (id != spec.SpecId)
            {
                return BadRequest();
            }

            _context.Entry(spec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("spec updated");
        }

        // POST: api/Specs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spec>> PostSpec([FromForm] Spec spec)
        {
            var product = await _context.Products.Where(s => s.ProductId == spec.SpecProductId).FirstOrDefaultAsync();
            if (product == null)
            {
                return BadRequest("product not found");
            }
            
            _context.Specs.Add(spec);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpec", new { id = spec.SpecId }, spec);
        }

        // DELETE: api/Specs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpec(int id)
        {
            var spec = await _context.Specs.FindAsync(id);
            if (spec == null)
            {
                return NotFound();
            }

            _context.Specs.Remove(spec);
            await _context.SaveChangesAsync();

            return Ok("spec deleted");
        }

        private bool SpecExists(int id)
        {
            return _context.Specs.Any(e => e.SpecId == id);
        }
    }
}
