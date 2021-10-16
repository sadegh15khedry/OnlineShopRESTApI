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
        public int Id { get; set; }

        [ForeignKey(nameof(Cart.Id))]
        public int CartId { get; set; }

        [ForeignKey(nameof(Product.Id))]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductOption))]
        public int ProductOptionId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; }
    }
}
