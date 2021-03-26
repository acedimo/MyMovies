using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using System;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        private IMoviesService _service { get; set; }

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public IActionResult Overview()
        {
            var movies = _service.GetAllMovies();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            try
            {
                var movie = _service.GetMovieById(id);

                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                return View(movie);
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorGeneral", "Info");
            }
            
        }
    }
}
