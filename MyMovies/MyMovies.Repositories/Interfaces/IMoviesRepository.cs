using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        List<Movie> GetAll();

        Movie GetById(int id);
    }
}
