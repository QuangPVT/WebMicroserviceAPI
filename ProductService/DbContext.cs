using MongoDB.Driver;
using ProductService.Models;

namespace ProductService
{
    public class DbContext
    {
        private readonly IMongoDatabase _database;

        public DbContext()
        {
            var dbHost = "localhost";
            var dbName = "dms_product";
            var connectString = $"mongodb://{dbHost}:27017/{dbName}";

            var mongoUrl = MongoUrl.Create(connectString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoCollection<Products> Products => _database.GetCollection<Products>("Products");
        public IMongoCollection<ProductInfo> ProductInfo => _database.GetCollection<ProductInfo>("Product_Info");
        public IMongoCollection<ProductType> ProductType => _database.GetCollection<ProductType>("Product_Type");
        public IMongoCollection<PageBanner> PageBanner => _database.GetCollection<PageBanner>("Page_Banner");

        // Nếu bạn có các collection khác, có thể thêm tương tự như trên
    }
}
