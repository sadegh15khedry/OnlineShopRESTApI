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

        //[ForeignKey(nameof(User))]
        //public int ImageProductId { get; set; }

        [ForeignKey(nameof(Option))]
        public int ImageProductOptionId { get; set; }

        public string ImagesUrl { get; set; }

        public string ImagesDescription { get; set; }

        [NotMapped]
        public IFormFile ImageImage { get; set; }
    }
}
