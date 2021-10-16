using Microsoft.AspNetCore.Http;
using ShopAPISourceCode.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        public List<UserAddress> UserAddress { get; set; }


        public List<Product> LikedProducts { get; set; }


        public List<Product> NoticeProduct { get; set; }


        public List<Review> Reviews { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
