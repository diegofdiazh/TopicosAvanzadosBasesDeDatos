namespace Netflix_Imdb.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
    }
}
