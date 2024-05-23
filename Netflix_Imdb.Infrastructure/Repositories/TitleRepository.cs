using MongoDB.Bson;
using MongoDB.Driver;
using Netflix_Imdb.Application.Entity;
using Netflix_Imdb.Application.Ports.Interfaces;
using Netflix_Imdb.Infrastructure.Persistence;

namespace Netflix_Imdb.Infrastructure.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly MongoDbContext _context;

        public TitleRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieTitle>> GetAllTitlesAsync()
        {
            return await _context.Titles.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<MovieTitle>> GetTitlesByCriteriaAsync(IEnumerable<string> genres, double? score)
        {
            var filterBuilder = Builders<MovieTitle>.Filter;
            var filter = filterBuilder.Empty;

            if (genres != null && genres.Any())
            {
                var genreFilters = genres.Select(genre => filterBuilder.Regex("ImdbData.Genre", new BsonRegularExpression(genre, "i")));
                filter &= filterBuilder.Or(genreFilters);
            }

            if (score.HasValue)
            {
                filter &= filterBuilder.Gte("ImdbData.Score", score.Value);
            }

            return await _context.Titles.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<MovieTitle>> GetTitlesByGenreAndRevenueAsync(IEnumerable<string> genres)
        {
            var filterBuilder = Builders<MovieTitle>.Filter;
            var filters = new List<FilterDefinition<MovieTitle>>();

            if (genres != null && genres.Any())
            {               
                filters.Add(filterBuilder.Or(genres.Select(genre => filterBuilder.Regex("imdb_data.genre", new BsonRegularExpression(genre, "i")))));
            }

            var filter = filterBuilder.And(filters);
            var sort = Builders<MovieTitle>.Sort.Descending("imdb_data.revenue");

            var titles = await _context.Titles.Find(filter).Sort(sort).ToListAsync();
            return titles;
        }
        public async Task<IEnumerable<MovieTitle>> GetAllTitlesByRevenueAsync()
        {
            var sort = Builders<MovieTitle>.Sort.Descending("imdb_data.revenue");
            var titles = await _context.Titles.Find(Builders<MovieTitle>.Filter.Empty).Sort(sort).ToListAsync();
            return titles;
        }
        public async Task<long> GetTitleCountAsync()
        {
            return await _context.Titles.CountDocumentsAsync(title => true);
        }
    }
}
