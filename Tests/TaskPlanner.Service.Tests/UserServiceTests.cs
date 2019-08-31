using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;
using Xunit;

namespace TaskPlanner.Service.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetAllUsersFromDbShouldCollectAllUserFromDatabase()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                                .UseInMemoryDatabase(databaseName: "Users_GetAll_Database")
                                .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var user = new ApplicationUser
            {
                Email = "pesho@abv.bg",
                FullName = "Pesho"
            };

            var user2 = new ApplicationUser
            {
                Email = "sasho@abv.bg",
                FullName = "Sasho"
            };

            var user3 = new ApplicationUser
            {
                Email = "gosho@abv.bg",
                FullName = "Gosho"
            };

            dbContext.Users.AddRange(user, user2, user3);
            dbContext.SaveChanges();

            var service = new UserService(dbContext);

            var actual = service.GetAllUsersFromDb();

            Assert.Equal(3, actual.Count);
        }

        [Fact]
        public void GetCurrentUserFromDbShouldReturnCorrectUser()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                    .UseInMemoryDatabase(databaseName: "Users_GetCurent_Database")
                    .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var user = new ApplicationUser
            {
                Email = "pesho@abv.bg",
                FullName = "Pesho"
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var service = new UserService(dbContext);

            var actual = service.GetCurrentUserFromDb(user.Id);

            var expected = dbContext.Users.FirstOrDefault(u => u.Id == user.Id);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PromoteUserShouldReturnTrue()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                                .UseInMemoryDatabase(databaseName: "Users_Promote_Database")
                                .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var user = new ApplicationUser
            {
                Email = "pesho@abv.bg",
                FullName = "Pesho"
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var service = new UserService(dbContext);

            service.PromoteUser(user);

            var actual = (ApplicationUser)dbContext.Users.FirstOrDefault(u => u.Id == user.Id);

            Assert.True(actual.IsPromoted);
        }
    }
}
