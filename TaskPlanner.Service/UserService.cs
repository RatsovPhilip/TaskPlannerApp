using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;
using TaskPlanner.Service.Common;
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

        public List<UserViewModel> GetAllUsersFromDb()
        {
            var allUsersFromDb = this.dbContext.Users.ToList();

            var result = Mapper.Map<List<UserViewModel>>(allUsersFromDb);

            return result;

        }

        public ApplicationUser GetCurrentUserFromDb(string currentUserId)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == currentUserId);
            
            return (ApplicationUser)user;
        }


    }
}
