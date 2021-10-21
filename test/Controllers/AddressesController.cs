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
            _dbCotext.SaveChanges();
            return StatusCode(201, address);
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{addressId}")]
        [Authorize]
        public IActionResult Put(int addressId, [FromForm] string? addressState, [FromForm] string? addressCounty,
            [FromForm] string? addressCity, [FromForm] string? addressHome, [FromForm] string? addressPostalCode)
        {
            int userId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            User myUser = _dbCotext.Users.Find(userId);
            var isNumeric = int.TryParse(addressPostalCode, out int addressPostalCodeNumber);
            Address myAddress = _dbCotext.Addresses.Find(addressId);

            if (myUser == null)
            {
                return StatusCode(500, "not a valid userId");
            }
            else if (myAddress == null)
            {
                return StatusCode(404, "address not found");
            }
            else if (myUser.UserId != myAddress.AddressUserId)
            {
                return StatusCode(500, "you are not alowed to update this address");
            }
            //valid requst going for update
            else
            {
                if (addressState != null)
                    myAddress.AddressState = addressState;

                if (addressCounty != null)
                    myAddress.AddressCounty = addressCounty;

                if (addressCity != null)
                    myAddress.AddressCity = addressCity;

                if (addressHome != null)
                    myAddress.AddressHome = addressHome;

                if (isNumeric == true && addressPostalCode != null)
                    myAddress.AddressPostalCode = addressPostalCodeNumber;

                _dbCotext.SaveChanges();
                //return Ok("address updated");
                return Ok(myAddress);
            }

        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{addressId}")]
        [Authorize]
        public IActionResult Delete(int addressId)
        {
            int userId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            User myUser = _dbCotext.Users.Find(userId);

            Address myAddress = _dbCotext.Addresses.Find(addressId);

            if (myUser == null)
            {
                return StatusCode(500, "not a valid userId");
            }
            else if (myAddress == null)
            {
                return StatusCode(404, "address not found");
            }
            else if (myUser.UserId != myAddress.AddressUserId)
            {
                return StatusCode(500, "you are not alowed to delete this address");
            }
            else
            {
                _dbCotext.Addresses.Remove(myAddress);
                _dbCotext.SaveChanges();
                return Ok("address removed");
            }
        }
    }
}
