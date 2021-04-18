using Microsoft.EntityFrameworkCore;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repositories
{
    public class MoviesRepository : BaseRepository<Movie>, IMoviesRepository
    {
        public MoviesRepository(MyMoviesDbContext context) : base(context)
        {}

        public List<Movie> GetMoviesWithFilters(string title)
        {
            var query = _context.Movies.Include(x => x.MovieGenre);

            if (title != null)
            {
                query.Where(x => x.Title.Contains(title));
            }

            return query.ToList();
        }

        public override Movie GetById(int entityId)
        {
            return _context.Movies
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == entityId);
        }

        public List<Movie> GetMostRecentMovies(int count)
        {
            return _context.Movies.OrderByDescending(x => x.DateCreated).Take(count).ToList();
        }

        public List<Movie> GetTopMovies(int count)
        {
            return _context.Movies.OrderByDescending(x => x.Views).Take(count).ToList();

        }
    }
}
