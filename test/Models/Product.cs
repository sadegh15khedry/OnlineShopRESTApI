using ShopAPISourceCode.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string ProductTitle { get; set; }

        public string ProductBrand { get; set; }

        public string ProductDescription { get; set; }

        public string ProductAnalysis { get; set; }
    }
}
