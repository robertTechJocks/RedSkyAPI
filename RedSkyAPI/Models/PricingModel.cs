using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RedSkyAPI.Models
{
    public class PricingModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("productId")]
        public int ProductId { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; }

    }
}
