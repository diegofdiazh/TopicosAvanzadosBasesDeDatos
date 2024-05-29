using Netflix_Imdb.Application.Entity;

namespace Netflix_Imdb.Application.Ports.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}