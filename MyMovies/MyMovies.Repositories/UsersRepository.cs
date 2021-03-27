using MyMovies.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repositories
{
    public class UsersRepository
    {
        private readonly MyMoviesDbContext _context;

        public UsersRepository(MyMoviesDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
