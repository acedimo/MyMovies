using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> Movies { get; set; }

        public MoviesController()
        {
            var movie1 = new Movie()
            {
                Id = 1,
                Title = "Batman",
                Duration = 120,
                Description = "asadasdadasd",
            };

            var movie2 = new Movie()
            {
                Id = 2,
                Title = "Batman",
                Duration = 120,
                Description = "asadasdadasd",
            };

            Movies = new List<Movie> { movie1, movie2 };
        }

        public IActionResult Overview()
        {
            return View(Movies);
        }

        public IActionResult Details(int id)
        {
            var movie = Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

            return View(movie);
        }
    }
}
