using MyMovies.Models;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Mappings
{
    public static class DomainModelExtensions
    {
        public static MovieOverviewModel ToOverviewModel(this Movie movie)
        {
            return new MovieOverviewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Description = movie.Description

            };

        }

        public static MovieManageOverviewModel ToManageOverviewModel(this Movie movie)
        {
            return new MovieManageOverviewModel()
            {
                Id = movie.Id,
                Title = movie.Title,

            };

        }

        public static MovieDetailsModel ToDetailsModel(this Movie movie)
        {
            return new MovieDetailsModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Duration = movie.Duration,
                Description = movie.Description,
                DateCreated = movie.DateCreated,
                Comments = movie.Comments.Select(x => x.ToCommentModel()).ToList()

            };

        }

        public static MovieCommentModel ToCommentModel(this Comment comment)
        {
            return new MovieCommentModel
            {
                Id = comment.Id,
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Username = comment.User.Username
            };
        }

        public static MovieUpdateModel ToUpdateModel(this Movie movie)
        {
            return new MovieUpdateModel
            {
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Duration = movie.Duration,
                Description = movie.Description
            };
        }

        public static UserDetailsModel ToDetailsModel(this User user)
        {
            return new UserDetailsModel
            {
                Username = user.Username,
                Address = user.Address,
                Email = user.Email
            };
        }

        public static UserManageOverviewModel ToManageOverviewModel(this User user)
        {
            return new UserManageOverviewModel
            {
                Username = user.Username,
                Id = user.Id,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
