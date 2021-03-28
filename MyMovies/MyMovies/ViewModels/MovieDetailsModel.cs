using System;

namespace MyMovies.ViewModels
{
    public class MovieDetailsModel
    {

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
