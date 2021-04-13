using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository : IBaseRepository<Movie>
    {
        List<Movie> GetByTitle(string title);
        List<Movie> GetMostRecentMovies(int count);
        List<Movie> GetTopMovies(int count);
    }
}
