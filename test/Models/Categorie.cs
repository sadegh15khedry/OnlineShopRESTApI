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
        public int CategorieId { set; get; }

        public string CategorieTitle { set; get; }

        public string CategorieMetaTitle { set; get; }

        [ForeignKey(nameof(Categorie))]
        public Categorie CategorieParent { set; get; }

        public string CategorieImageUrl { get; set; }


        public virtual ICollection<ProductCategorie> CategorieProducts { get; set; }

        [NotMapped]
        public IFormFile CategorieImage { get; set; }


    }
}
