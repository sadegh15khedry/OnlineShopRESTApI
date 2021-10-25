using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using test.Data;
using test.Models;

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public AddressesController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }


        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutAddress(int id, [FromForm] Address address)
        {
            var isUserIdValid = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            User myUser = await _context.Users.FindAsync(userId);
            Address myAddress =  await _context.Addresses.FindAsync(id);

            if (myUser == null)
            {
                return BadRequest("user not valid");
            }

            else if (myAddress.AddressUserId != myUser.UserId)
            {
                return Unauthorized("you are not allowed to update this address");
            }

            myAddress.AddressCity = address.AddressCity;
            myAddress.AddressCounty = address.AddressCounty;
            myAddress.AddressHome = address.AddressHome;
            myAddress.AddressPostalCode = address.AddressPostalCode;
            myAddress.AddressState = address.AddressState;

            await _context.SaveChangesAsync();
            return Ok("addres updated");
        }


        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Address>> PostAddress([FromForm] Address address)
        {
            var isUserIdValid = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            User myUser = await _context.Users.FindAsync(userId);

            if (myUser == null)
                return BadRequest("user not valid");

            address.AddressUserId = myUser.UserId;
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.AddressId }, address);
        }


        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var isUserIdValid = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            User myUser = await _context.Users.FindAsync(userId);

            var myAddress = await _context.Addresses.FindAsync(id);
            if (myAddress == null)
            {
                return NotFound("address not found");
            }
            else if (myAddress.AddressUserId != myUser.UserId)
                return Unauthorized("you are not allowed to delete this address");

            _context.Addresses.Remove(myAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressId == id);
        }
    }
}
