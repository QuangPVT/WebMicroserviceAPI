using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class ProductType
    {
        [BsonElement("product_type_id"), BsonRepresentation(BsonType.String)]
        public string ProductTypeId { get; set; }
        
        [BsonElement("all_tech_tag")]
        public List<string> AllTechTag { get; set; }

    }
}
