using MyMovies.Services.DtoModels;

namespace MyMovies.Services.Interfaces
{
    public interface ICommentsService
    {
        StatusModel Add(string comment, int movieId, int userId);
    }
}
