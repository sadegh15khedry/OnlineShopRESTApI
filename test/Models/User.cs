using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ShopAPISourceCode.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace test.Models
{
    public class User
    {
        public int UserId { set; get; }

        public string UserFirstName { set; get; }

        public string UserLastName { set; get; }

        public double UserSSN { set; get; }

        public string UserEmail { set; get; }

        public string UserPassword { set; get; }

        public double UserPhone { set; get; }

        public string UserRole { set; get; }

        public string UserImageUrl { get; set; }

        public IFormFile UserImage { get; set; }
    }
}
