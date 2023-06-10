using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using YourAppName.Models;

namespace YourAppName.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var adoptionPlans = user.AdoptionPlans;

            return View("Index", adoptionPlans);
        }

        [Authorize]
        public IActionResult Show()
        {
            return View();
        }
    }
}
