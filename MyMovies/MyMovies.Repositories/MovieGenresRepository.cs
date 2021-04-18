using MyMovies.Models;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories
{
    public class MovieGenresRepository : BaseRepository<MovieGenre>, IMovieGenresRepository
    {
        public MovieGenresRepository(MyMoviesDbContext context) : base(context)
        {
        }
    }
}
