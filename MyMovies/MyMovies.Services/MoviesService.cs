using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        private IMoviesRepository _movieRepository { get; set; }

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _movieRepository = moviesRepository;
        }
        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public void CreateMovie(Movie movie)
        {
            _movieRepository.Create(movie);
        }

        public List<Movie> GetMoviesByTitle(string title)
        {
            if (title == null)
            {
                return _movieRepository.GetAll();
            }
            else
            {
                return _movieRepository.GetByTitle(title);
            }
        }
    }
}
