using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }


        public Product ImageProduct { get; set; }


        public Option ImageProductOption { get; set; }

        public string ImagesUrl { get; set; }

        [NotMapped]
        public IFormFile ImageImage { get; set; }
    }
}
