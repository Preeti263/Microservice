using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Rmq.Application.Producer.TransactionDTO
{
    public class TransactionDetails
    {
        [JsonConstructor]
        public TransactionDetails() { }
        public Guid Id { get; set; }
        public string TransactionId { get; set; }
        public string TransactionAmount { get; set; }
        public string CardType { get; set; }

        public string MerchantID { get; set; }

    }
}
