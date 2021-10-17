using Microsoft.AspNetCore.Http;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Brand { get; set; }

        public string Description { get; set; }

        public string Analysis { get; set; }


        public ICollection<Categorie> Categories { get; set; }

        [InverseProperty(nameof(User.LikedProducts))]
        public ICollection<User> UsersLiked { get; set; }

        [InverseProperty(nameof(User.NoticeProduct))]
        public ICollection<User> UsersNotice { get; set; }

        public ICollection<ProductTag> ProductTag { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }

        public ICollection<ProductMeta> ProductMetas { get; set; }


        public ICollection<ProductSpec> ProductSpecs { get; set; }

    }
}
