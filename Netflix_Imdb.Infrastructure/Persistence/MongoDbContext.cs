using MongoDB.Driver;
using Netflix_Imdb.Application.Entity;

namespace Netflix_Imdb.Infrastructure.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<MovieTitle> Titles => _database.GetCollection<MovieTitle>("merged_data");
    }
}
