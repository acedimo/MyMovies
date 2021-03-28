using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var response = _authService.SignIn(signInModel.Username, signInModel.Password, HttpContext);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("Overview", "Movies");

                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(signInModel);

                }
            }
            return View(signInModel);
        }
    }
}
