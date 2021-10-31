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
    public class MetasController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public MetasController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Metas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meta>>> GetMeta()
        {
            return await _context.Meta.ToListAsync();
        }

        // GET: api/Metas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meta>> GetMeta(int id)
        {
            var meta = await _context.Meta.FindAsync(id);

            if (meta == null)
            {
                return NotFound();
            }

            return meta;
        }

        [HttpGet("[action]/{productId}")]
        public async Task<ActionResult<Meta>> GetMetasByProductId(int productId)
        {
            var meta = await _context.Meta.Where(s => s.MetaProductId == productId).ToListAsync();

            if (meta == null)
            {
                return NotFound();
            }

            return Ok(meta);
        }

        // PUT: api/Metas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeta(int id,[FromForm] Meta meta)
        {
            if (id != meta.MetaId)
            {
                return BadRequest();
            }

            _context.Entry(meta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("meta updated");
        }

        // POST: api/Metas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meta>> PostMeta([FromForm] Meta meta)
        {
            var product = await _context.Products.Where(s => s.ProductId == meta.MetaProductId).FirstOrDefaultAsync();
            if (product == null)
            {
                return BadRequest("product not found");
            }

            _context.Meta.Add(meta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeta", new { id = meta.MetaId }, meta);
        }

        // DELETE: api/Metas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeta(int id)
        {
            var meta = await _context.Meta.FindAsync(id);
            if (meta == null)
            {
                return NotFound();
            }

            _context.Meta.Remove(meta);
            await _context.SaveChangesAsync();

            return Ok("meta deleted");
        }

        private bool MetaExists(int id)
        {
            return _context.Meta.Any(e => e.MetaId == id);
        }
    }
}
