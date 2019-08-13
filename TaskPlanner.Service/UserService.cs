using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;
using TaskPlanner.Service.Common;

namespace TaskPlanner.Service
{
    public class UserService : IUserService
    {
        private readonly TaskPlannerDbContext dbContext;

        public UserService(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApplicationUser GetCurrentUserFromDb(string currentUserId)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == currentUserId);

            return (ApplicationUser)user;
        }


    }
}
