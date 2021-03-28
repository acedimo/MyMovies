using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Linq;

namespace MyMovies.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MyMoviesDbContext _context;

        public UsersRepository(MyMoviesDbContext context)
        {
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
