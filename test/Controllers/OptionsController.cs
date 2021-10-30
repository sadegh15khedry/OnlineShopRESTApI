using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Data;
using test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private ShopDbContext _context;

        public OptionsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/<OptionsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
        {
            return await _context.Options.ToListAsync();
        }

        // GET api/<OptionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Option>>> GetOption(int id)
        {
            var option = await _context.Options.FindAsync(id);
            if (option == null)
                return NotFound("option not found");

            return Ok(option);
        }


        [HttpGet("[action]/{productId}")]
        public async Task<ActionResult<IEnumerable<Option>>> GetOptionByProduct(int productId)
        {
            var option = await _context.Options.Where(s => s.OptionProductId == productId).ToListAsync();
            if (option == null)
                return NotFound("option not found");

            return Ok(option);
        }




        // PUT api/<OptionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption(int id, [FromForm] Option option)
        {

            if (id != option.OptionId)
            {
                return BadRequest();
            }
            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
                {
                    return NotFound("product not found");
                }
                else
                {
                    throw;
                }
            }

            return Ok("option updated");
        }


        // POST api/<OptionsController>
        [HttpPost]
        public async Task<ActionResult<Option>> PostOption([FromForm] Option option)
        {

            var myProduct = _context.Products.Find(option.OptionProductId);
            if (myProduct == null)
            {
                return NotFound("product not found");
            }
            else
            {
                _context.Options.Add(option);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOption", new { id = option.OptionId }, option);
            }
        }


        //DELETE api/<OptionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var myOpton = await _context.Options.FindAsync(id);

            if (myOpton == null)
            {
                return NotFound("option not found");
            }

            _context.Options.Remove(myOpton);
            await _context.SaveChangesAsync();
            return Ok("option deleted");
        }


        private bool OptionExists(int id)
        {
            return _context.Options.Any(e => e.OptionId == id);
        }
    }



}
