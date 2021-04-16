using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyMovies.Common.Options;
using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Services
{
    public class SidebarService : ISidebarService
    {
        private readonly IMoviesService _service;
        private readonly SidebarConfig _sidebarConfig;

        public SidebarService(IMoviesService service, IOptions<SidebarConfig> sidebarConfig )
        {
            _service = service;
            _sidebarConfig = sidebarConfig.Value;
        }

        public MovieSideBarDataModel GetSidebarData()
        {

            var sidebarDataModel = new MovieSideBarDataModel();

            var mostRecentMovies = _service.GetMostRecentMovies(_sidebarConfig.MostRecentMoviesCount);
            var topMovies = _service.GetTopMovies(_sidebarConfig.TopMoviesCount);

            sidebarDataModel.MostRecentMovies = mostRecentMovies.Select(x => x.ToMovieSideBarModel()).ToList();
            sidebarDataModel.TopMovies = topMovies.Select(x => x.ToMovieSideBarModel()).ToList();

            return sidebarDataModel;
        }
    }
}
