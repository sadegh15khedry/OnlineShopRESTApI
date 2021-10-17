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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User User { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public double Total { get; set; }

        public double MoneySaved { get; set; }

        public double PayingPrice { get; set; }
       
        public string Status { get; set; }

        
    }
}
