using MyMovies.Models;
using MyMovies.ViewModels;

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
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Duration = movie.Duration,
                Description = movie.Description,
                DateCreated = movie.DateCreated

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
    }
}
