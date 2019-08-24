using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public interface IUserService
    {
        ApplicationUser GetCurrentUserFromDb(string Id);

        List<ApplicationUser> GetAllUsersFromDb();

        List<ApplicationUser> GetAllUsersFromCompany(List<ApplicationUser> allUsersFromDb,string companyName);
    }
}
