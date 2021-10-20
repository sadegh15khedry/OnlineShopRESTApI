﻿using ShopAPISourceCode.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public string ProductTitle { get; set; }

        [Required]
        public string ProductBrand { get; set; }

        public string ProductDescription { get; set; }

        public string ProductAnalysis { get; set; }


        public virtual ICollection<ProductCategorie> ProductCategories { get; set; }

        public virtual ICollection<Like> ProductLikes { get; set; }

        public virtual ICollection<Notice> ProductNotices { get; set; }

        public ICollection<Tag> ProductTags { get; set; }

        public ICollection<Review> ProductReviews { get; set; }

        public ICollection<Meta> ProductMetas { get; set; }


        public ICollection<Spec> ProductSpecs { get; set; }

    }
}