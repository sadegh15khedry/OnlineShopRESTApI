﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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