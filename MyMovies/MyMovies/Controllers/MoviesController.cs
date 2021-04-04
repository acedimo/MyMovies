using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Mappings;
using MyMovies.Models;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class MoviesController : Controller
    {
        private IMoviesService _service { get; set; }

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            var user = User;

            var movies = _service.GetMoviesByTitle(title);

            var movieOverviewModels = movies.Select(x => x.ToOverviewModel()).ToList();

            return View(movieOverviewModels);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var movie = _service.GetMovieById(id);

                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                return View(movie.ToDetailsModel());
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorGeneral", "Info");
            }

        }

        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var movies = _service.GetAllMovies();

            var viewModels = movies.Select(x => x.ToManageOverviewModel()).ToList();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateModel movie)
        {
            if (ModelState.IsValid)
            {
                var domainModel = movie.ToModel();
                _service.CreateMovie(domainModel);
                return RedirectToAction("ManageOverview", new { SuccessMessage = "Movie created successfully"});
            }

            return View(movie);
            
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var response = _service.Delete(id);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Movie deleted successfully" });

                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });

                }
            }
            catch(Exception)
            {
                return RedirectToAction("InternalError", "Info");
            }
            
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var movie = _service.GetMovieById(id);

            if (movie == null)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = "Movie not found" });
            }

            return View(movie.ToUpdateModel());
        }

        [HttpPost]
        public IActionResult Update(MovieUpdateModel movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = _service.Update(movie.ToModel());

                    if (response.IsSuccessful)
                    {
                        return RedirectToAction("ManageOverview", new { SuccessMessage = "Movie updated successfully" });

                    }
                    else
                    {
                        return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });

                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("InternalError", "Info");
                }

            }

            return View(movie);
        }
    }
}
