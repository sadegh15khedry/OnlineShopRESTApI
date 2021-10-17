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
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public string Title { set; get; }

        public string MetaTitle { set; get; }

        public Categorie Parent { set; get; }

        public string ImageUrl { get; set; }

        public ICollection<Product> Product { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }


    }
}
