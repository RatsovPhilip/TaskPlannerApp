﻿namespace TaskPlanner.Service
{
    using Data;
    using Data.Models;
    using ViewModels;

    public class ProfileService : IProfileService
    {
        private readonly TaskPlannerDbContext dbContext;
        private readonly IUserService userService;

        public ProfileService(TaskPlannerDbContext dbContext,IUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public void EditCurrentUserProfile(ProfileEditPostViewModel viewModel)
        {
            var user = this.userService.GetCurrentUserFromDb(viewModel.Id);

            user.Email = viewModel.Email;
            user.FullName = viewModel.FullName;

            var image = this.userService.GetUserImage(viewModel.Id);

            if(image == null)
            {
                image = new Image();
            }

            image.ImageUrl = viewModel.Id + ".jpg";

            user.Images.Add(image);

            dbContext.SaveChanges();
        }
    }
}
