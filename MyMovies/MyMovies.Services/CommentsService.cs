
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class CommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public List<Comment> GetAll()
        {
            return _commentsRepository.GetAll();
        }
    }
}
