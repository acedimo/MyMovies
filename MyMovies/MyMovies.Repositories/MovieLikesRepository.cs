using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Linq;

namespace MyMovies.Repositories
{
    public class MovieLikesRepository : BaseRepository<MovieLike>, IMovieLikesRepository
    {
        public MovieLikesRepository(MyMoviesDbContext context) : base(context)
        {
        }

        public MovieLike Get(int movieId, int userId)
        {
            return _context.MovieLikes.FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);
        }
    }
}
