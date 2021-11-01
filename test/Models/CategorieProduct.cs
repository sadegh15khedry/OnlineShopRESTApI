using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class CategorieProduct
    {
        public int CategorieProductId { set; get; }

        public int CategorieProductProductId { get; set; }

        public int CategorieProductCategorieId { get; set; }

        public DateTime CategorieProductDateTimeAdded { get; set; }

    }
}
