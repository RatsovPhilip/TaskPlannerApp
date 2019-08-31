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
        private readonly IProfileService profileService;

        public ProfileController(UserManager<ApplicationUser> userManager, IUserService userService,IProfileService profileService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.profileService = profileService;
        }

        public IActionResult Me()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = userService.GetCurrentUserFromDb(userId);
            if (user.CompanyName == null)
            {
                return this.Redirect("/");
            }

            var image = this.userService.GetUserImage(userId);

            var model = new ProfileEditViewModel
            {
                Email = user.Email,
                FullName = user.FullName,
                CompanyName = user.CompanyName,
                Images = image.ImageUrl

            };

            return this.View(model);
        }

        public IActionResult Edit()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = userService.GetCurrentUserFromDb(userId);
            if (user.CompanyName == null)
            {
                return this.Redirect("/");
            }

            var image = this.userService.GetUserImage(userId);

            var model = new ProfileEditViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                CompanyName = user.CompanyName,
                Images = image.ImageUrl

            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProfileEditPostViewModel viewModel)
        {
            this.profileService.EditCurrentUserProfile(viewModel);

            using (var file = System.IO.File.OpenWrite($"wwwroot/img/{viewModel.Id}.jpg"))
            {
                viewModel.Images.CopyTo(file);
            }

                return this.Redirect("/Profile/Me");
        }
    }
}
