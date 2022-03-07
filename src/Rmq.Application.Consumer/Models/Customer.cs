using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithMongoDB.WebAPI.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string TransactionId { get; set; }
        public string TransactionAmount { get; set; }
        public string CardType { get; set; }

        public string MerchantID { get; set; }
    }
}
