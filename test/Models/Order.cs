using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public User OrderUser { get; set; }

        public List<OrderItem> OrderOrderItems { get; set; }

        public DateTime OrderCreatedAt { get; set; }

        public DateTime OrderUpdatedAt { get; set; }

        public double OrderTotal { get; set; }

        public double OrderMoneySaved { get; set; }

        public double OrderPayingPrice { get; set; }
       
        public string OrderStatus { get; set; }

        
    }
}
