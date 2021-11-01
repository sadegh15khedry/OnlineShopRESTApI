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
        public int NoticeId { set; get; }

        public int NoticeUserId { get; set; }

        public int NoticeProductId { get; set; }

        public DateTime NoticeDateTimeAdded { get; set; }
    
    }
}
