using MyMovies.Models;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
        User GetById(int userId);
        bool CheckIfExists(string username, string email);
        void Add(User newUser);
    }
}
