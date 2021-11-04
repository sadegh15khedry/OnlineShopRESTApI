using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public string AddressState { get; set; }

        public string AddressCounty { get; set; }

        public string AddressCity { get; set; }

        public string AddressHome { get; set; }

        public double AddressPostalCode { set; get; }

        public int AddressUserId { get; set; }

    }
}
