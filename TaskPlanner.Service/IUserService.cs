using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TaskPlanner.Data.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Service
{
    public interface IUserService
    {
        ApplicationUser GetCurrentUserFromDb(string Id);

        List<ApplicationUser> GetAllUsersFromDb();

        void PromoteUser(ApplicationUser user);
    }
}
