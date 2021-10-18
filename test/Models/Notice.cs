using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Notice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoticeId { set; get; }

        public User NoticeUser { get; set; }

        public Product NoticeProduct { get; set; }

        public DateTime NoticeDateTimeAdded { get; set; }
    
    }
}
