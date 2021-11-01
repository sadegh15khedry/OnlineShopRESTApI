using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public Order OrderItemOrder { get; set; }

        public Product OrderItemProduct { get; set; }

        public Option OrderItemProductOption { get; set; }

        public int OrderItemQuantity { get; set; }

        public DateTime OrderItemCreatedAt { get; set; }

        public DateTime OrderItemUpdatedAt { get; set; }

        public string OrderItemStatus { get; set; }
    }
}
