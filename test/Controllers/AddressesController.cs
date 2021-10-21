using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPISourceCode.Models;
using System;
using System.Linq;
using System.Security.Claims;
using test.Data;
using test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private ShopDbContext _dbCotext;

        public AddressesController(ShopDbContext dbCotext)
        {
            _dbCotext = dbCotext;
        }


        // GET: api/<AddressesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbCotext.Addresses);
        }

        // GET api/<AddressesController>/GetUserAddresses
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetUserAddresses()
        {
            int userId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            var myAddress = _dbCotext.Addresses.Where(s => s.AddressUserId == userId);
            return Ok(myAddress);
        }

        //POST api/<AddressesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] string addressState, [FromForm] string addressCounty,
            [FromForm] string addressCity, [FromForm] string addressHome, [FromForm] string addressPostalCode)
        {
            int userId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            User myUser = _dbCotext.Users.Find(userId);
            var isNumeric = int.TryParse(addressPostalCode, out int addressPostalCodeNumber);
            if (myUser == null)
            {
                return StatusCode(500, "not a valid userId");
            }

            else if (isNumeric == false)
            {
                return StatusCode(405, "not a valid postal code");
            }

            Address address = new Address
            {
                AddressState = addressState,
                AddressCounty = addressCounty,
                AddressCity = addressCity,
                AddressHome = addressHome,
                AddressPostalCode = Int32.Parse(addressPostalCode),
                AddressUserId = myUser.UserId
            };

            _dbCotext.Addresses.Add(address);
            //myUser.UserAddresses.Add(address);
            _dbCotext.SaveChanges();

            return StatusCode(201, address);


        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
