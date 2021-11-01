using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Categorie
    {
        public int CategorieId { set; get; }

        public string CategorieTitle { set; get; }

        public string CategorieMetaTitle { set; get; }

        public int? CategorieParentId { set; get; }

        public string CategorieImageUrl { get; set; }

        public IFormFile CategorieImage { get; set; }


    }
}
