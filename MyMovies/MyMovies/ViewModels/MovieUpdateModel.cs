using System.ComponentModel.DataAnnotations;

namespace MyMovies.ViewModels
{
    public class MovieUpdateModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
