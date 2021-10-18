using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }


        public Order TransactionOrder { get; set; }


        public User TransactionUser { get; set; }

        public int TransactionType { get; set; }

        public string TransactionStatus { get; set; }

        public DateTime TransactionCreatedAt { get; set; }

        public DateTime TransactionUpdatedAt { get; set; }

        public string TransactionContext { get; set; }

        public double TransactionPaidPrice { get; set; }

    }
}
