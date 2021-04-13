using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieSideBarDataModel
    {
        public List<MovieSideBarModel> TopMovies { get; set; } = new List<MovieSideBarModel>();
        public List<MovieSideBarModel> MostRecentMovies { get; set; } = new List<MovieSideBarModel>();

    }
}
