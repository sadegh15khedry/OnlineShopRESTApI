using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPISourceCode.Models;
using System;
using System.IO;
using System.Linq;
using test.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private ShopDbContext _dbCotext;

        public ImagesController(ShopDbContext dbCotext)
        {
            _dbCotext = dbCotext;
        }



        // GET: api/<ImagesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbCotext.Images);
        }

        [HttpGet("[action]/{optionId}")]
        public IActionResult GetOptionImages(int optionId)
        {
            var myOption = _dbCotext.Options.Find(optionId);
            
            if (myOption == null)
                return NotFound("option not found");

            var myImages = _dbCotext.Images.Where(s => s.ImageProductOptionId == optionId);
            return Ok(myImages);

        }
            // GET api/<ImagesController>/5
            [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var myImage = _dbCotext.Images.Find(id);

            if (myImage == null)
            {
                return NotFound("image not found");
            }
            else
            {
                return Ok(myImage);
            }
        }


        // POST api/<ImagesController>
        [HttpPost]
        public IActionResult Post([FromForm] IFormFile imageImage, [FromForm] string imagesDescription, 
            [FromForm] string imageProductOptionId)
        {
            var isIdNumeric = Int32.TryParse(imageProductOptionId, out int imageOptionIdNumber);
            if(isIdNumeric == false)
            {
                return NotFound("product option not found");
            }
            else if(imageImage != null)
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot/img", guid + ".jpg");
                var fileStream = new FileStream(filePath, FileMode.Create);
                imageImage.CopyTo(fileStream);

                Image myImage = new Image 
                {
                    ImagesUrl = filePath.Remove(0, 7)
                };
                myImage.ImageProductOptionId = imageOptionIdNumber;
                myImage.ImagesDescription = imagesDescription;
                
                _dbCotext.Images.Add(myImage);
                _dbCotext.SaveChanges();
                return Ok("image added");
            }
            var myOption = _dbCotext.Options.Find();
            return Ok();
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myImage = _dbCotext.Images.Find(id);
            if (myImage == null)
            {
                return NotFound("image not found");
            }
            _dbCotext.Images.Remove(myImage);
            _dbCotext.SaveChanges();
            return Ok("image deleted");
        }
    }
}
