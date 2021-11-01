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

        public int OrderItemOrderId { get; set; }

        public int OrderItemOptionId { get; set; }

        public int OrderItemQuantity { get; set; }

        public DateTime OrderItemCreatedAt { get; set; }

        public DateTime OrderItemUpdatedAt { get; set; }

        public string OrderItemStatus { get; set; }
    }
}
