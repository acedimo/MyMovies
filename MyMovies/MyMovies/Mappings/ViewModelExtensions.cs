using MyMovies.Models;
using MyMovies.ViewModels;

namespace MyMovies.Mappings
{
    public static class ViewModelExtensions
    {
        public static Movie ToModel(this MovieCreateModel viewModel)
        {
            return new Movie
            {
                Title = viewModel.Title,
                ImageUrl = viewModel.ImageUrl,
                Duration = viewModel.Duration,
                Description = viewModel.Description,
                MovieGenreId = viewModel.MovieGenreId
            };
        }

        public static Movie ToModel(this MovieUpdateModel viewModel)
        {
            return new Movie
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                ImageUrl = viewModel.ImageUrl,
                Duration = viewModel.Duration,
                Description = viewModel.Description,
                MovieGenreId = viewModel.MovieGenreId
            };
        }

        public static User ToModel(this SignUpModel user)
        {
            return new User()
            {
                Password = user.Password,
                Username = user.Username,
                Address = user.Address,
                Email = user.Email
            };
        }
    }
}
