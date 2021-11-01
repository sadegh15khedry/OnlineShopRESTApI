using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public int CartUserId { get; set; }

        public DateTime CartCreatedAt { get; set; }
        
        public DateTime CartUpdatedAt { get; set; }

        public string CartStatus { get; set; }

    }
}
