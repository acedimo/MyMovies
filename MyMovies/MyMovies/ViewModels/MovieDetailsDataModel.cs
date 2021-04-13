namespace MyMovies.ViewModels
{
    public class MovieDetailsDataModel
    {
        public MovieDetailsModel MovieDetails { get; set; }
        public MovieSideBarDataModel SideBarData { get; set; } = new MovieSideBarDataModel();
    }
}
