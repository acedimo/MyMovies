﻿using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class MovieGenresService : IMovieGenresService
    {
        private readonly IMovieGenresRepository _movieGenresRepository;

        public MovieGenresService(IMovieGenresRepository movieGenresRepository)
        {
            _movieGenresRepository = movieGenresRepository;
        }

        public List<MovieGenre> GetAll()
        {
            return _movieGenresRepository.GetAll();
        }

        public bool CheckIfExists(int movieGenreId)
        {
            var movieGenre = _movieGenresRepository.GetById(movieGenreId);

            return movieGenre != null;
        }
    }
}
