using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;

namespace MyMovies.Controllers
{
    [Authorize]
    public class MovieLikesController : Controller
    {
        private readonly IMovieLikesService _movieLikesService;

        public MovieLikesController(IMovieLikesService movieLikesService)
        {
            _movieLikesService = movieLikesService;
        }

        public IActionResult Add(int movieId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _movieLikesService.Add(movieId, userId);

            return RedirectToAction("Overview", "Movies");
        }

        public IActionResult Remove(int movieId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _movieLikesService.Remove(movieId, userId);

            return RedirectToAction("Overview", "Movies");
        }
    }
}
