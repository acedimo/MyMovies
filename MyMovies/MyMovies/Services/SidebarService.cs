using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Services
{
    public class SidebarService : ISidebarService
    {
        private readonly IMoviesService _service;

        public SidebarService(IMoviesService service)
        {
            _service = service;
        }

        public MovieSideBarDataModel GetSidebarData()
        {

            var sidebarDataModel = new MovieSideBarDataModel();

            var mostRecentMovies = _service.GetMostRecentMovies(5);
            var topMovies = _service.GetTopMovies(5);

            sidebarDataModel.MostRecentMovies = mostRecentMovies.Select(x => x.ToMovieSideBarModel()).ToList();
            sidebarDataModel.TopMovies = topMovies.Select(x => x.ToMovieSideBarModel()).ToList();

            return sidebarDataModel;
        }
    }
}
