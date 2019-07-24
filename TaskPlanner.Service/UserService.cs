using Microsoft.AspNetCore.Identity;
using System.Linq;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public class UserService : IUserService
    {
        private readonly TaskPlannerDbContext dbContext;

        public UserService(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ApplicationUser GetCurrentUser(string currentUserId)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == currentUserId);

            return (ApplicationUser)user;
        }
    }
}
