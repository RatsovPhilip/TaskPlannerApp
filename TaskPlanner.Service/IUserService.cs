namespace TaskPlanner.Service
{
    using System.Collections.Generic;
    using Data.Models;

    public interface IUserService
    {
        ApplicationUser GetCurrentUserFromDb(string Id);

        List<ApplicationUser> GetAllUsersFromDb();

        void PromoteUser(ApplicationUser user);

        Image GetUserImage(string userId);
    }
}
