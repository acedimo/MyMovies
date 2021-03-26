using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public List<Movie> Movies { get; set; }

        public MoviesRepository()
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

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
