using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OrderService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class Orders
    {
        [BsonId]
        [BsonElement("order_id"), BsonRepresentation(BsonType.String)]
        public string OrderId { get; set; }

        [BsonElement("user_id"), BsonRepresentation(BsonType.String)]
        public string UserId { get; set; }

        [BsonElement("discount_id"), BsonRepresentation(BsonType.String)]
        public string DiscountId { get; set; }

        [BsonElement("full_name"), BsonRepresentation(BsonType.String)]
        public string FullName { get; set; }

        [BsonElement("phone"), BsonRepresentation(BsonType.String)]
        public string Phone { get; set; }

        [BsonElement("address"), BsonRepresentation(BsonType.String)]
        public string Address { get; set; }

        [BsonElement("payment_type"), BsonRepresentation(BsonType.String)]
        public string PaymentType { get; set; }

        [BsonElement("gender"), BsonRepresentation(BsonType.Boolean)]
        public string Gender { get; set; }

        [BsonElement("company_invoice"), BsonRepresentation(BsonType.Boolean)]
        public string CompanyInvoice { get; set; }

        [BsonElement("note"), BsonRepresentation(BsonType.String)]
        public string Note { get; set; }

        [BsonElement("cost_price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal cost_price { get; set; }

        [BsonElement("discount_price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal DiscountPrice { get; set; }

        [BsonElement("date_time"), BsonRepresentation(BsonType.DateTime)]
        public string DateTime { get; set; }

    }
}
