using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class PageBanner
    {

        [BsonElement("banner_id"), BsonRepresentation(BsonType.String)]
        public string BannerId { get; set; }

        [BsonElement("banner_link"), BsonRepresentation(BsonType.String)]
        public string BannerLink { get; set; }
    }
}
