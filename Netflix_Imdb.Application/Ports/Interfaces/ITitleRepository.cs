using Netflix_Imdb.Application.Entity;

namespace Netflix_Imdb.Application.Ports.Interfaces
{
    public interface ITitleRepository
    {
        Task<long> GetTitleCountAsync();
        Task<IEnumerable<MovieTitle>> GetAllTitlesAsync();
        Task<IEnumerable<MovieTitle>> GetTitlesByCriteriaAsync(IEnumerable<string> genres, double? score);
        Task<IEnumerable<MovieTitle>> GetTitlesByGenreAndRevenueAsync(IEnumerable<string> genres);
        Task<IEnumerable<MovieTitle>> GetAllTitlesByRevenueAsync();

    }
}
