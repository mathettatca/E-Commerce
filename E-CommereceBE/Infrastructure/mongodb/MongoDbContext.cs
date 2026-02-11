using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Domain.Models;
using Infrastructure.mongodb.Repository;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    // Constructor nhận vào Connection String và Tên DB
    public MongoDbContext(IConfiguration configuration)
    {
        // 1. Gọi hàm config mapping trước khi làm bất cứ thứ gì
        MongoDbConfig.Configure();

        // 2. Lấy thông tin từ file appsettings.json
        var connectionString = configuration.GetConnectionString("MongoDbConnection");
        var databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");

        // 3. Khởi tạo Client và Database
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    // Hoặc viết hàm Generic dùng chung cho nhiều model
    // Cách 2: Hàm Generic để lấy bất kỳ Repository nào (nếu bạn lười khai báo từng cái)
    public IMongoRepository<T> GetRepository<T>(string collectionName) where T : class
    {
        return new MongoRepository<T>(_database, collectionName);
    }
}