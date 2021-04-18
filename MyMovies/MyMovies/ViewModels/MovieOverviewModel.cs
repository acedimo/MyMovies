using System.Collections.Generic;

namespace MyMovies.ViewModels
{
    public class MovieOverviewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int Views { get; set; }

        public string MovieGenre { get; set; }
        public List<MovieLikeModel> MovieLikes { get; set; }
    }
}
