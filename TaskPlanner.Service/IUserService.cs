using Microsoft.AspNetCore.Identity;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public interface IUserService
    {
        ApplicationUser GetCurrentUserFromDb(string Id);
    }
}
