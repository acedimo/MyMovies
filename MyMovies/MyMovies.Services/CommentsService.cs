using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;

namespace MyMovies.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMoviesService _moviesService;

        public CommentsService(ICommentsRepository commentsRepository, IMoviesService moviesService)
        {
            _commentsRepository = commentsRepository;
            _moviesService = moviesService;
        }

        public StatusModel Add(string comment, int movieId, int userId)
        {
            var response = new StatusModel();

            var movie = _moviesService.GetMovieById(movieId);

            if (movie != null)
            {

                var newComment = new Comment()
                {

                    Message = comment,
                    DateCreated = DateTime.Now,
                    MovieId = movieId,
                    UserId = userId
                };

                _commentsRepository.Add(newComment);

            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The movie with id {movieId} was not found";
            }

            return response;
            
        }
    }
}
