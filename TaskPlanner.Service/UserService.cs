using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Service
{
    public class UserService : IUserService
    {
        private readonly TaskPlannerDbContext dbContext;

        public UserService(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ApplicationUser> GetAllUsersFromDb()
        {
            var allUsersFromDb = this.dbContext.Users.ToList();

            var result = new List<ApplicationUser>();

            foreach (var user in allUsersFromDb)
            {
                result.Add((ApplicationUser)user);
            }

            return result;

        }

        public ApplicationUser GetCurrentUserFromDb(string currentUserId)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == currentUserId);
            
            return (ApplicationUser)user;
        }

        public Image GetUserImage(string userId)
        {
            return this.dbContext.Images.FirstOrDefault(i => i.ApplicationUserId == userId);
        }

        public void PromoteUser(ApplicationUser user)
        {
            user.IsPromoted = true;
            dbContext.SaveChanges();
        }
    }
}
