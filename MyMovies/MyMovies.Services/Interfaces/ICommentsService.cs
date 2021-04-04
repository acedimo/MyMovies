
namespace MyMovies.Services.Interfaces
{
    public interface ICommentsService
    {
        void Add(string comment, int movieId, int userId);
    }
}
