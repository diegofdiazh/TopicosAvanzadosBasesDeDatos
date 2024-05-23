using Netflix_Imdb.Application.Entity;

namespace Netflix_Imdb.Application.Services.Interfaces
{
    public interface ITitleService
    {
        Task<(IEnumerable<MovieTitle> Titles, long Count)> GetAllTitlesAsync();
        Task<(IEnumerable<MovieTitle> Titles, long Count)> SearchTitlesAsync(IEnumerable<string> genres, double? score);
        Task<(IEnumerable<MovieTitle> Titles, long Count)> GetTitlesByGenreAndRevenueAsync(IEnumerable<string> genres);
        Task<(IEnumerable<MovieTitle> Titles, long Count)> GetAllTitlesByRevenueAsync();
    }
}
