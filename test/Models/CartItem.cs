using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public int CartItemCartId { get; set; }

        public int CartItemOptionId { get; set; }

        public DateTime CartItemCreatedAt { get; set; }

        public DateTime CartItemUpdatedAt { get; set; }

        public int CartItemQuantity { get; set; }

        public string CartItemStatus { get; set; }
    }
}
