using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ShopAPISourceCode.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { set; get; }

        public string UserFirstName { set; get; }

        public string UserLastName { set; get; }

        public double UserSSN { set; get; }

        public string UserEmail { set; get; }

        public string UserPassword { set; get; }

        public double UserPhone { set; get; }

        public string UserRole { set; get; }

        
        //public virtual ICollection<Address> UserAddresses { set; get; }

        public virtual ICollection<Like> UserLikes { get; set; }

        public virtual ICollection<Notice> UserNotices { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
