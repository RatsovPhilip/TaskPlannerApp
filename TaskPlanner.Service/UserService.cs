using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
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

        public List<ApplicationUser> GetAllUsersFromCompany(List<ApplicationUser> allUsersFromDb, string companyName)
        {
            return allUsersFromDb.Where(user => user.CompanyName == companyName).ToList();
        }

        public List<ApplicationUser> GetAllUsersFromDb()
        {
            var allUsersFromDb = this.dbContext.Users.ToList();

            var result = new List<ApplicationUser>();

            foreach (var item in allUsersFromDb)
            {
                result.Add((ApplicationUser)item);
            }

            return result;

        }

        public ApplicationUser GetCurrentUserFromDb(string currentUserId)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == currentUserId);
            
            return (ApplicationUser)user;
        }


    }
}
