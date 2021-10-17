using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class UserAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string State { get; set; }

        public string County { get; set; }

        public string City { get; set; }

        public string Home { get; set; }

        public double PostalCode { set; get; }

        public User User { get; set; }
    }
}
