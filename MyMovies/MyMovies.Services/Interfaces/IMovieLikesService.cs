namespace MyMovies.Services.Interfaces
{
    public interface IMovieLikesService
    {
        void Add(int movieId, int userId);
        void Remove(int movieId, int userId);
    }
}
