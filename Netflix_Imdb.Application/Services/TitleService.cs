using Netflix_Imdb.Application.Entity;
using Netflix_Imdb.Application.Ports.Interfaces;
using Netflix_Imdb.Application.Services.Interfaces;

namespace Netflix_Imdb.Application.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IRedisCache _redisCache;

        public TitleService(ITitleRepository titleRepository, IRedisCache redisCache)
        {
            _titleRepository = titleRepository;
            _redisCache = redisCache;
        }

        public async Task<(IEnumerable<MovieTitle> Titles, long Count)> GetAllTitlesAsync()
        {
            var cacheKey = "all_titles";
            var cachedTitles = await _redisCache.GetCacheData<IEnumerable<MovieTitle>>(cacheKey);

            if (cachedTitles != null)
            {
                var count = cachedTitles.Count();
                return (cachedTitles, count);
            }

            var titles = await _titleRepository.GetAllTitlesAsync();
            var countFromDb = await _titleRepository.GetTitleCountAsync();

          
            await _redisCache.SetCacheData(cacheKey, titles, DateTimeOffset.Now.AddHours(1));

            return (titles, countFromDb);
        }

        public async Task<(IEnumerable<MovieTitle> Titles, long Count)> SearchTitlesAsync(IEnumerable<string> genres, double? score)
        {
            var cacheKey = $"search_titles_{string.Join(",", genres)}_{score}";
            var cachedTitles = await _redisCache.GetCacheData<IEnumerable<MovieTitle>>(cacheKey);

            if (cachedTitles != null)
            {
                var count = cachedTitles.Count();
                return (cachedTitles, count);
            }

            var titles = await _titleRepository.GetTitlesByCriteriaAsync(genres, score);
            var countFromDb = titles.Count();

          
            await _redisCache.SetCacheData(cacheKey, titles, DateTimeOffset.Now.AddHours(1));

            return (titles, countFromDb);
        }

        public async Task<(IEnumerable<MovieTitle> Titles, long Count)> GetTitlesByGenreAndRevenueAsync(IEnumerable<string> genres)
        {
            var cacheKey = $"titles_by_genre_revenue_{string.Join(",", genres)}";
            var cachedTitles = await _redisCache.GetCacheData<IEnumerable<MovieTitle>>(cacheKey);

            if (cachedTitles != null)
            {
                var count = cachedTitles.Count();
                return (cachedTitles, count);
            }

            var titles = await _titleRepository.GetTitlesByGenreAndRevenueAsync(genres);
            var countFromDb = titles.Count();

       
            await _redisCache.SetCacheData(cacheKey, titles, DateTimeOffset.Now.AddHours(1));

            return (titles, countFromDb);
        }

        public async Task<(IEnumerable<MovieTitle> Titles, long Count)> GetAllTitlesByRevenueAsync()
        {
            var cacheKey = "all_titles_by_revenue";
            var cachedTitles = await _redisCache.GetCacheData<IEnumerable<MovieTitle>>(cacheKey);

            if (cachedTitles != null)
            {
                var count = cachedTitles.Count();
                return (cachedTitles, count);
            }

            var titles = await _titleRepository.GetAllTitlesByRevenueAsync();
            var countFromDb = titles.Count();

        
            await _redisCache.SetCacheData(cacheKey, titles, DateTimeOffset.Now.AddHours(1));

            return (titles, countFromDb);
        }
    }
}

