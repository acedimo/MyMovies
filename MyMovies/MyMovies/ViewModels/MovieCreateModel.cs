using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.ViewModels
{
    public class MovieCreateModel
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int MovieGenreId { get; set; }

        public List<MovieGenreModel> MovieGenres { get; set; }

    }
}
