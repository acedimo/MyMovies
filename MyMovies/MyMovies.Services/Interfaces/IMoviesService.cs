using MyMovies.Models;
using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAllMovies();

        List<Movie> GetMoviesWithFilters(string title);

        Movie GetMovieById(int id);
        StatusModel CreateMovie(Movie movie);
        StatusModel Delete(int id);
        StatusModel Update(Movie movie);
        public Movie GetMovieDetails(int id);
        List<Movie> GetMostRecentMovies(int count);
        List<Movie> GetTopMovies(int count);
    }
}
