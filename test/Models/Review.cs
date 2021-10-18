using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { set; get; }
        
        public string ReviewTitle { set; get; }

        public int ReviewRating { get; set; }//zero to five

        public int ReviewStatus { get; set; }

        public string ReviewContext { set; get; }
        
        public  User ReviewUser { set; get; }

        public Product ReviewProduct { set; get; }

    }
}
