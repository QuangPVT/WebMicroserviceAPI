using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OrderService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class OrderLists
    {
        [BsonElement("order_id"), BsonRepresentation(BsonType.String)]
        public string OrderId { get; set; }

        [BsonElement("product_id"), BsonRepresentation(BsonType.String)]
        public string ProductId { get; set; }

        [BsonElement("quantity"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Quantity { get; set; }

        [BsonElement("unit_price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal UnitPrice { get; set; }
    }
}
