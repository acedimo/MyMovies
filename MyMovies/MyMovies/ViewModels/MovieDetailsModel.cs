using System;
using System.Collections.Generic;

namespace MyMovies.ViewModels
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        public int Views { get; set; }

        public List<MovieCommentModel> Comments { get; set; }
    }
}
