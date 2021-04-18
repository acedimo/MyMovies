using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Models;
using MyMovies.Common.Services;
using MyMovies.Mappings;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Linq;

namespace MyMovies.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class MoviesController : Controller
    {
        private IMoviesService _moviesService { get; set; }
        private ISidebarService _sidebarService { get; set; }

        private readonly IMovieGenresService _movieGenresService;
        private readonly ILogService _logService;

        public MoviesController(
            IMoviesService moviesService,
            ISidebarService sidebarService,
            IMovieGenresService movieGenresService,
            ILogService logService)
        {
            _moviesService = moviesService;
            _sidebarService = sidebarService;
            _movieGenresService = movieGenresService;
            _logService = logService;
        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            var user = User;

            var movies = _moviesService.GetMoviesWithFilters(title);

            var overviewDataModel = new MovieOverviewDataModel();

            var movieOverviewModels = movies.Select(x => x.ToOverviewModel()).ToList();
            overviewDataModel.OverviewMovies = movieOverviewModels;

            overviewDataModel.SidebarData = _sidebarService.GetSidebarData();

            return View(overviewDataModel);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var movie = _moviesService.GetMovieDetails(id);

                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                var movieDetailsDataModel = new MovieDetailsDataModel();

                movieDetailsDataModel.MovieDetails = movie.ToDetailsModel();

                movieDetailsDataModel.SideBarData = _sidebarService.GetSidebarData();


                return View(movieDetailsDataModel);
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
            var movies = _moviesService.GetAllMovies();

            var viewModels = movies.Select(x => x.ToManageOverviewModel()).ToList();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var movieGenres = _movieGenresService.GetAll();
            var viewModels = movieGenres.Select(x => x.ToMovieGenreModel()).ToList();

            var viewModel = new MovieCreateModel();
            viewModel.MovieGenres = viewModels;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateModel movie)
        {
            if (ModelState.IsValid)
            {
                var domainModel = movie.ToModel();
                var response = _moviesService.CreateMovie(domainModel);

                if (response.IsSuccessful)
                {
                    var userId = User.FindFirst("Id");
                    var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with id {userId} created recipe {movie.Title}" };
                    _logService.Log(logData);

                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Movie created successfully" });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }

                
            }

            var movieGenres = _movieGenresService.GetAll();
            var viewModels = movieGenres.Select(x => x.ToMovieGenreModel()).ToList();

            movie.MovieGenres = viewModels;

            return View(movie);
            
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var response = _moviesService.Delete(id);
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
            var movie = _moviesService.GetMovieById(id);

            if (movie == null)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = "Movie not found" });
            }

            var viewModel = movie.ToUpdateModel();

            var movieGenres = _movieGenresService.GetAll();
            var viewModels = movieGenres.Select(x => x.ToMovieGenreModel()).ToList();

            viewModel.MovieGenres = viewModels;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(MovieUpdateModel movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = _moviesService.Update(movie.ToModel());

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
