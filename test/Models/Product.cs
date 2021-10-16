using Microsoft.AspNetCore.Http;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Brand { get; set; }

        public string Description { get; set; }

        public string Analysis { get; set; }


        public List<Categorie> Categories { get; set; }


        public List<ProductTag> ProductTag { get; set; }


        public List<Review> Reviews { get; set; }


        public List<ProductMeta> ProductMetas { get; set; }


        public List<ProductSpec> ProductSpecs { get; set; }

    }
}
