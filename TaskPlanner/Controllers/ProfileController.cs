namespace TaskPlanner.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Data.Models;
    using Service;
    using ViewModels;
    using Microsoft.AspNetCore.Authorization;

    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public ProfileController(UserManager<ApplicationUser> userManager, IUserService userService, IProfileService profileService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.profileService = profileService;
        }

        [Authorize]
        public IActionResult Me()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = userService.GetCurrentUserFromDb(userId);
            if (user.CompanyName == null)
            {
                return this.Redirect("/");
            }

            var image = this.userService.GetUserImage(userId);
            var model = new ProfileEditViewModel();

            if (image == null)
            {
                model.Id = user.Id;
                model.Email = user.Email;
                model.FullName = user.FullName;
                model.CompanyName = user.CompanyName;

            }
            else
            {
                model.Id = user.Id;
                model.Email = user.Email;
                model.FullName = user.FullName;
                model.CompanyName = user.CompanyName;
                model.Images = image.ImageUrl;
            }

            return this.View(model);
        }

        [Authorize]
        public IActionResult Edit()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = userService.GetCurrentUserFromDb(userId);
            if (user.CompanyName == null)
            {
                return this.Redirect("/");
            }

            var image = this.userService.GetUserImage(userId);

            var model = new ProfileEditViewModel();

            if (image == null)
            {
                model.Id = user.Id;
                model.Email = user.Email;
                model.FullName = user.FullName;
                model.CompanyName = user.CompanyName;

            }
            else
            {
                model.Id = user.Id;
                model.Email = user.Email;
                model.FullName = user.FullName;
                model.CompanyName = user.CompanyName;
                model.Images = image.ImageUrl;
            }

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
