﻿using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;

namespace MyMovies.Services
{

    public class MovieLikesService : IMovieLikesService
    {
        private readonly IMovieLikesRepository _movieLikesRepository;

        public MovieLikesService(IMovieLikesRepository movieLikesRepository)
        {
            _movieLikesRepository = movieLikesRepository;
        }
        public void Add(int movieId, int userId)
        {
            var like = _movieLikesRepository.Get(movieId, userId);
            if (like == null)
            {
                var newLike = new MovieLike();
                newLike.MovieId = movieId;
                newLike.UserId = userId;

                _movieLikesRepository.Add(newLike);
            }

        }

        public void Remove(int movieId, int userId)
        {
            var like = _movieLikesRepository.Get(movieId, userId);

            if (like != null)
            {
                _movieLikesRepository.Delete(like);

            }
        }
    }
}
