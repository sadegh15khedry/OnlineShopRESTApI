using Microsoft.AspNetCore.Mvc;
using ShopAPISourceCode.Models;
using System;
using test.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private ShopDbContext _dbCotext;

        public OptionsController(ShopDbContext dbCotext)
        {
            _dbCotext = dbCotext;
        }

        // GET: api/<OptionsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbCotext.Options);
        }

        // GET api/<OptionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var myOption = _dbCotext.Options.Find(id);
            if (myOption == null)
                return NotFound("option not found");
            return Ok(myOption);
        }

        // POST api/<OptionsController>
        [HttpPost]
        public IActionResult Post([FromForm] int optionProductId, [FromForm] double optionPrice, [FromForm] double optionQuantity,
            [FromForm] float optionDiscount, [FromForm] string optionDiscountStart, [FromForm] string optionType)
        {

            var myProduct = _dbCotext.Products.Find(optionProductId);
            if (myProduct == null)
            {
                return NotFound("product not found");
            }
            else
            {
                Option option = new Option
                {
                    OptionProductId = myProduct.ProductId,
                    OptionPrice = optionPrice,
                    OptionDiscount = optionDiscount,
                    OptionQuantity = optionQuantity,
                    OptionType = optionType
                };
                _dbCotext.Options.Add(option);
                _dbCotext.SaveChanges();
                return Ok("option added");
            }
        }

        // PUT api/<OptionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] string optionPrice, [FromForm] string optionQuantity,
            [FromForm] string optionDiscount, [FromForm] string optionDiscountStart,
            [FromForm] string optionDiscountEnd, [FromForm] string optionType)
        {
            var myOption = _dbCotext.Options.Find(id);

            if (myOption == null)
            {
                return NotFound("option not found");
            }


            var isPriceNumeric = double.TryParse(optionPrice, out double optionPriceNummber);
            if (isPriceNumeric == true)
                myOption.OptionPrice = optionPriceNummber;

            var isDiscountNumeric = float.TryParse(optionDiscount, out float optionDiscountNummber);
            if (isDiscountNumeric == true)
                myOption.OptionDiscount = optionDiscountNummber;

            var isQuantityNumeric = double.TryParse(optionQuantity, out double optionQuantityNumber);
            if (isQuantityNumeric == true)
                myOption.OptionQuantity = optionQuantityNumber;

            if (optionType != null)
                myOption.OptionType = optionType;

            var isDiscoutStartValid = DateTime.TryParse(optionDiscountStart, out DateTime optionDiscountStartDateTime);
            if (isDiscoutStartValid == true)
                myOption.OptionDiscountStart = optionDiscountStartDateTime;

            var isDiscoutEndValid = DateTime.TryParse(optionDiscountEnd, out DateTime optionDiscountEndDateTime);
            if (isDiscoutEndValid == true)
                myOption.OptionDiscountEnd = optionDiscountEndDateTime;

            _dbCotext.SaveChanges();
            return Ok("option updated");
        }

        //DELETE api/<OptionsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myOpton = _dbCotext.Options.Find(id);

            if (myOpton == null)
            {
                return NotFound("option not found");
            }

            _dbCotext.Options.Remove(myOpton);
            _dbCotext.SaveChanges();
            return Ok("option deleted");
        }
    }



}
