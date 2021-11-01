using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        public string TagTitle { get; set; }

        public string TagMetaTitle { get; set; }

        public string TagSlug { get; set; }

        public string TagContext { get; set; }

    }
}
