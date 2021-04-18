using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IMovieGenresService
    {
        List<MovieGenre> GetAll();
        bool CheckIfExists(int movieGenreId);
    }
}
