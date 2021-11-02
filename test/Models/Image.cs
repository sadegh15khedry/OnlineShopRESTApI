using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public int ImageOptionId { get; set; }

        public string ImageUrl { get; set; }

        public string ImagesDescription { get; set; }

        public IFormFile ImageImage { get; set; }
    }
}
