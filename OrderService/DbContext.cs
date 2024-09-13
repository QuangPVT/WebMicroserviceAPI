using MongoDB.Driver;
using OrderService.Models;

namespace OrderService
{
    public class DbContext
    {
        private readonly IMongoDatabase _database;

        public DbContext()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var connectString = $"mongodb://{dbHost}:27017/{dbName}";

            var mongoUrl = MongoUrl.Create(connectString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoCollection<Orders> Orders => _database.GetCollection<Orders>("Orders");
        public IMongoCollection<OrderDiscount> OrderDiscount => _database.GetCollection<OrderDiscount>("Order_Discount");
        public IMongoCollection<OrderLists> OrderLists => _database.GetCollection<OrderLists>("Order_Lists");
        // Nếu bạn có các collection khác, có thể thêm tương tự như trên
    }
}
