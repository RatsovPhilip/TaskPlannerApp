namespace TaskPlanner.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Data.Models;
    using Service;

    public class FirstLogInController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public FirstLogInController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        public IActionResult Create()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = this.userService.GetCurrentUserFromDb(userId);

            if (user.CompanyName == null)
            {
                return this.View();
            }

            return NotFound();
        }
    }
}
