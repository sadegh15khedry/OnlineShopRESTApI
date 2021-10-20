﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }


        public List<CartItem> CartItems { get; set; }

        
        public User CartUser { get; set; }

        public DateTime CartCreatedAt { get; set; }
        
        public DateTime CartUpdatedAt { get; set; }

        public string CartStatus { get; set; }

    }
}