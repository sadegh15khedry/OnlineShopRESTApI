using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class User
    {
        [Key]
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public double Phone { set; get; }
        public string Address { set; get; }
        public string Role { set; get; }
        public double PostalCode { set; get; }
        public double SSN { set; get; }



        public string ImageUrl { get; set; }

        //public Dictionary<string, string> specs;
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
