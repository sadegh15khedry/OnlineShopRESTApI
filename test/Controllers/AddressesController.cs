using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Data;

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

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var myAddress = _dbCotext.Users.Find(id);
            if (myAddress == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(myAddress);
            }
        }

        // POST api/<AddressesController>
        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{

        //}

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
