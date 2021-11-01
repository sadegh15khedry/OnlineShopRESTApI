using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int TransactionOrderId { get; set; }

        public int TransactionType { get; set; }

        public string TransactionStatus { get; set; }

        public DateTime TransactionCreatedAt { get; set; }

        public DateTime TransactionUpdatedAt { get; set; }

        public string TransactionContext { get; set; }

        public double TransactionPaidPrice { get; set; }

    }
}
