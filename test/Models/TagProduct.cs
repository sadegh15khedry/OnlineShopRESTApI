using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPISourceCode.Models
{
    public class TagProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagProductId { get; set; }
        public int TagProductProductId { get; set; }
        public int TagProductTagId { get; set; }

    }
}
