using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Like
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LikeId { set; get; }
        //[Column("LikeUserId")]
        public virtual User LikeUser { get; set; }
 
        public virtual Product LikeProduct { get; set; }

        public DateTime LikeDateTimeAdded { get; set; }
    }
}
