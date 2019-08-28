using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Service;

namespace TaskPlanner.Controllers
{
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
