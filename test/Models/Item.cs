using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Brand { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        public string ImageUrl { get; set; }

        //public Dictionary<string, string> specs;

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
