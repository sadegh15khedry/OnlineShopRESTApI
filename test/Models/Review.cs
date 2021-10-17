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
        public int Id { set; get; }
        
        public string Title { set; get; }

        public int Rating { get; set; }//zero to five

        public int Status { get; set; }

        public string ReviewContext { set; get; }
        

        public  User User { set; get; }

        public Product Product { set; get; }

    }
}
