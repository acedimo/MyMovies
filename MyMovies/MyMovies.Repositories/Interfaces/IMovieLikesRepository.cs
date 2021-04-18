using MyMovies.Models;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMovieLikesRepository : IBaseRepository<MovieLike>
    {
        MovieLike Get(int movieId, int userId);
    }
}
