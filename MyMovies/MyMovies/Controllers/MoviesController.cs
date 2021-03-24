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
        public IActionResult Index()
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
                Id = 1,
                Title = "Batman",
                Duration = 120,
                Description = "asadasdadasd",
            };

            var movies = new List<Movie> { movie1, movie2 };

            return View(movies);
        }
    }
}
