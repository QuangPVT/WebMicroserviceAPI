using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class Products
    {
        [BsonElement("product_id"), BsonRepresentation(BsonType.String)]
        public string ProductId { get; set; }

        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement("list_price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal ListedPrice { get; set; }

        [BsonElement("current_price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal CurrentPrice { get; set; }

        [BsonElement("total_review"), BsonRepresentation(BsonType.Int32)]
        public int TotalReview { get; set; }

        [BsonElement("star_rating"), BsonRepresentation(BsonType.Double)]
        public double StarRating { get; set; }

        [BsonElement("status"), BsonRepresentation(BsonType.Boolean)]
        public bool Status { get; set; }
    }
}
