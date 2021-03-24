﻿using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
using MyMovies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesService _service { get; set; }

        public MoviesController()
        {
            _service = new MoviesService();
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
