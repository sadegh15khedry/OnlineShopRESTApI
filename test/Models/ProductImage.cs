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
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Product.Id))]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductOption.Id))]
        public int ProductOptionId { get; set; }

        public string ImagesUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
