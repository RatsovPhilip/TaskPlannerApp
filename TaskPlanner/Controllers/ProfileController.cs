using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Service;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public ProfileController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        public IActionResult Me()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = userService.GetCurrentUserFromDb(userId);
            if (user.CompanyName == null)
            {
                return this.Redirect("/");
            }

            var model = Mapper.Map<UserViewModel>(user);

            return this.View(model);
        }
    }
}
