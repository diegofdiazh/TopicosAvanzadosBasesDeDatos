using Netflix_Imdb.Application.Entity;
using Netflix_Imdb.Application.Ports.Interfaces;
using Netflix_Imdb.Application.Services.Interfaces;

namespace Netflix_Imdb.Application.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;

        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public async Task<(IEnumerable<MovieTitle> Titles, long Count)> GetAllTitlesAsync()
        {
            var titles = await _titleRepository.GetAllTitlesAsync();
            var count = await _titleRepository.GetTitleCountAsync();
            return (titles, count);
        }

        public async Task<(IEnumerable<MovieTitle> Titles, long Count)> SearchTitlesAsync(IEnumerable<string> genres, double? score)
        {
            var titles = await _titleRepository.GetTitlesByCriteriaAsync(genres, score);
            var count = titles.Count();
            return (titles, count);
        }

        public async Task<(IEnumerable<MovieTitle> Titles, long Count)> GetTitlesByGenreAndRevenueAsync(IEnumerable<string> genres)
        {
            var titles = await _titleRepository.GetTitlesByGenreAndRevenueAsync(genres);
            var count = titles.Count();
            return (titles, count);
        }
        public async Task<(IEnumerable<MovieTitle> Titles, long Count)> GetAllTitlesByRevenueAsync()
        {
            var titles = await _titleRepository.GetAllTitlesByRevenueAsync();
            var count = titles.Count();
            return (titles, count);
        }
    }
}
