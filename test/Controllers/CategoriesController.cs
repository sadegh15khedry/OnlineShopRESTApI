using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using test.Data;

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public CategoriesController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> GetCategorie(int id)
        {
            var categorie = await _context.Categories.FindAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }

            return categorie;
        }

        // GET: api/Categories1/5
        [HttpGet("[action]/{parentId}")]
        public async Task<ActionResult<Categorie>> GetCategoriesByParentId(int parentId)
        {
            var categories = await _context.Categories.Where(s => s.CategorieParentId == parentId).ToListAsync();

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorie(int id, [FromForm] Categorie categorie)
        {
            if (id != categorie.CategorieId)
            {
                return BadRequest();
            }
            if (categorie.CategorieImage != null)
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot/img", guid + ".jpg");
                var fileStream = new FileStream(filePath, FileMode.Create);
                await categorie.CategorieImage.CopyToAsync(fileStream);

                categorie.CategorieImageUrl = filePath.Remove(0, 7);
                categorie.CategorieImage = null;
            }

            _context.Entry(categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("categorie updated");
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorie>> PostCategorie([FromForm] Categorie categorie)
        {
            if (categorie.CategorieImage != null)
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot/img", guid + ".jpg");
                var fileStream = new FileStream(filePath, FileMode.Create);
                await categorie.CategorieImage.CopyToAsync(fileStream);
                
                categorie.CategorieImageUrl = filePath.Remove(0, 7);
                categorie.CategorieImage = null;

                _context.Categories.Add(categorie);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCategorie", new { id = categorie.CategorieId }, categorie);

            }
            else
            {
                return BadRequest("not a valid image");
            }
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorie", new { id = categorie.CategorieId }, categorie);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie(int id)
        {
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categorie);
            await _context.SaveChangesAsync();

            return Ok("categorie deleted");
        }

        private bool CategorieExists(int id)
        {
            return _context.Categories.Any(e => e.CategorieId == id);
        }
    }
}
