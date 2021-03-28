﻿using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
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
            movie.DateCreated = DateTime.Now;
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

        public void Delete(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null)
            {
                throw new NotFoundException($"The movie with id {id} was not found");
            }
            else
            {
                _movieRepository.Delete(movie);
            }
        }

        public void Update(Movie movie)
        {

            var updatedMovie = _movieRepository.GetById(movie.Id);

            if (updatedMovie != null)
            {

                updatedMovie.Title = movie.Title;
                updatedMovie.ImageUrl = movie.ImageUrl;
                updatedMovie.Duration = movie.Duration;
                updatedMovie.Description = movie.Description;
                updatedMovie.DateModified = DateTime.Now;

                _movieRepository.Update(updatedMovie);

            }
            else
            {
                throw new NotFoundException($"The movie with id {movie.Id} was not found");

            }

        }
    }
}
