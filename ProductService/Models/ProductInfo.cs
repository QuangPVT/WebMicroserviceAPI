using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class ProductInfo
    {
        [BsonElement("product_id"), BsonRepresentation(BsonType.String)]
        public string ProductId { get; set; }

        [BsonElement("product_type_id"), BsonRepresentation(BsonType.String)]
        public string ProductTypeId { get; set; }

        [BsonElement("image_list")]
        public List<string> ImageList { get; set; }

        [BsonElement("context"), BsonRepresentation(BsonType.String)]
        public string Context { get; set; }

        [BsonElement("tech_tag")]
        public List<string> TechTag { get; set; }

        [BsonElement("tag_search")]
        public List<string> TagSearch { get; set; }
    }
}
