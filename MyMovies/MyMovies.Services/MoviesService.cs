using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMovieGenresService _movieGenresService;

        private IMoviesRepository _movieRepository { get; set; }

        public MoviesService(IMoviesRepository moviesRepository, IMovieGenresService movieGenresService)
        {
            _movieRepository = moviesRepository;
            _movieGenresService = movieGenresService;
        }
        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public Movie GetMovieDetails(int id)
        {
            var movie = GetMovieById(id);

            if (movie == null)
            {
                return movie;
            }

            movie.Views++;

            _movieRepository.Update(movie);

            return movie;
        }

        public StatusModel CreateMovie(Movie movie)
        {
            var response = new StatusModel();

            if (!_movieGenresService.CheckIfExists(movie.MovieGenreId))
            {
                response.IsSuccessful = false;
                response.Message = $"Movie genre with id {movie.MovieGenreId} does not exist.";
                return response;
            }

            movie.DateCreated = DateTime.Now;
            _movieRepository.Add(movie);

            return response;
        }

        public List<Movie> GetMoviesWithFilters(string title)
        {
            return _movieRepository.GetMoviesWithFilters(title);
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var movie = _movieRepository.GetById(id);

            if (movie == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The movie with id {id} was not found";
            }
            else
            {
                _movieRepository.Delete(movie);
            }

            return response;
        }

        public StatusModel Update(Movie movie)
        {

            var response = new StatusModel();
            var updatedMovie = _movieRepository.GetById(movie.Id);

            if (updatedMovie != null)
            {

                updatedMovie.Title = movie.Title;
                updatedMovie.ImageUrl = movie.ImageUrl;
                updatedMovie.Duration = movie.Duration;
                updatedMovie.Description = movie.Description;
                updatedMovie.DateModified = DateTime.Now;
                updatedMovie.MovieGenreId = movie.MovieGenreId;

                _movieRepository.Update(updatedMovie);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The movie with id {movie.Id} was not found";

            }

            return response;

        }

        public List<Movie> GetMostRecentMovies(int count)
        {
            return _movieRepository.GetMostRecentMovies(count);
        }

        public List<Movie> GetTopMovies(int count)
        {
            return _movieRepository.GetTopMovies(count);

        }
    }
}
