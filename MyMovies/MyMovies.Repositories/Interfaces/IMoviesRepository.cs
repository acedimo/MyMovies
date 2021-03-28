using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        List<Movie> GetAll();
        List<Movie> GetByTitle(string title);
        Movie GetById(int id);
        void Create(Movie movie);
        void Delete(Movie movie);
        void Update(Movie movie);
    }
}
