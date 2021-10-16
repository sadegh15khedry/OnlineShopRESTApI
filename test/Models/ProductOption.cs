using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class ProductOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Product.Id))]
        public int ProductId { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        public float Discount { get; set; }

        public DateTime DiscountStrt { get; set; }

        public DateTime DiscountEnd { get; set; }

        public string Type { get; set; }
    }
}
