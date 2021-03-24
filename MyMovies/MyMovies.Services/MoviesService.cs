using MyMovies.Models;
using MyMovies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Services
{
    public class MoviesService
    {
        private MoviesRepository _movieRepository { get; set; }

        public MoviesService()
        {
            _movieRepository = new MoviesRepository();
        }
        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public object GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }
    }
}
