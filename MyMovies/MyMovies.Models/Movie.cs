using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Models
{
    public class Movie
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

        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified{ get; set; }

        public int Views { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
