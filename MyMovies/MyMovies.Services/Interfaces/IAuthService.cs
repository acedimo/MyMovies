using Microsoft.AspNetCore.Http;
using MyMovies.Models;
using MyMovies.Services.DtoModels;

namespace MyMovies.Services.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext);
        void SignOut(HttpContext httpContext);
        StatusModel SignUp(User user);
    }
}
