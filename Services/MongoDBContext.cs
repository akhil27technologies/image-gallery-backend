using Gallery_Backend.Configurations;
using Gallery_Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Gallery_Backend.Services
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Image> Images => _database.GetCollection<Image>("Images");
    }
}
