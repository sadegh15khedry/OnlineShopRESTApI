using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Option
    {
        public int OptionId { get; set; }

        public int OptionProductId { get; set; }

        public double OptionPrice { get; set; }

        public double OptionQuantity { get; set; }

        public float OptionDiscount { get; set; }

        public DateTime OptionDiscountStart { get; set; }

        public DateTime OptionDiscountEnd { get; set; }

        public string OptionType { get; set; }

    }
}
