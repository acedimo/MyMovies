using MyMovies.Models;

namespace MyMovies.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
    }
}
