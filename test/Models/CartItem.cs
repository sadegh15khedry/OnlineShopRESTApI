using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }


        public Cart CartItemCart { get; set; }


        public Product CartItemProduct { get; set; }

        public Option CartItemProductOption { get; set; }

        public DateTime CartItemCreatedAt { get; set; }

        public DateTime CartItemUpdatedAt { get; set; }

        public int CartItemQuantity { get; set; }

        public string CartItemStatus { get; set; }
    }
}
