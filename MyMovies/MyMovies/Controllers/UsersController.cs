using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Mappings;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System.Linq;

namespace MyMovies.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IUsersService UsersService { get; }

        [Authorize]
        public IActionResult Details()
        {
            var userId = User.FindFirst("Id").Value;
            var user = _usersService.GetDetails(userId);

            if (user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

            return View(user.ToDetailsModel());
        }

        [Authorize(Policy = "IsAdmin")]
        public IActionResult ManageOverview( string successMessage, string errorMesssage)
        {
            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMesssage = errorMesssage;


            var id = int.Parse(User.FindFirst("Id").Value);

            var users = _usersService.GetAll();
            var viewModel = users.Where(x => x.Id != id).Select(x => x.ToManageOverviewModel()).ToList();
            return View(viewModel);
        }

        [Authorize(Policy = "IsAdmin")]
        public IActionResult ToggleAdminRole(int id)
        {
            var response = _usersService.ToggleAdminRole(id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = "User updated successfully" });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMesssage = response.Message });

            }
        }

        [Authorize(Policy = "IsAdmin")]
        public IActionResult Delete(int id)
        {
            var response = _usersService.Delete(id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = "User deleted successfully" });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMesssage = response.Message });

            }
        }
    }
}
