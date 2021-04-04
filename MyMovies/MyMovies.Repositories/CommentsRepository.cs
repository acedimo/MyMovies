using MyMovies.Models;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories
{
    public class CommentsRepository : BaseRepository<Comment>, ICommentsRepository
    {

        public CommentsRepository(MyMoviesDbContext context) : base(context)
        {

        }
    }
}
