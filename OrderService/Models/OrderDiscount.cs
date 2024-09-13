using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OrderService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class OrderDiscount
    {
        [BsonElement("discount_id"), BsonRepresentation(BsonType.String)]
        public string DiscountId { get; set; }

        [BsonElement("product_type"), BsonRepresentation(BsonType.String)]
        public string ProductType { get; set; }

        [BsonElement("cost_min"), BsonRepresentation(BsonType.Decimal128)]
        public decimal CostMin { get; set; }

        [BsonElement("max_discount"), BsonRepresentation(BsonType.Decimal128)]
        public decimal MaxDiscount { get; set; }

        [BsonElement("quantity"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Quantity { get; set; }

        [BsonElement("in_used"), BsonRepresentation(BsonType.Decimal128)]
        public decimal InUsed { get; set; }

        [BsonElement("type"), BsonRepresentation(BsonType.String)]
        public string Type { get; set; }

        [BsonElement("status"), BsonRepresentation(BsonType.Boolean)]
        public bool Status { get; set; }
    }
}
