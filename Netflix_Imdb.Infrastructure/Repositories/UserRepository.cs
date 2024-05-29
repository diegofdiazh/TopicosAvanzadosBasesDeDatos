using Microsoft.EntityFrameworkCore;
using Netflix_Imdb.Application.Ports.Interfaces;
using Netflix_Imdb.Application.Entity;
using Netflix_Imdb.Infrastructure.Persistence;

namespace Netflix_Imdb.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDbContext _context;

        public UserRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(u => u.Role)
                                       .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
