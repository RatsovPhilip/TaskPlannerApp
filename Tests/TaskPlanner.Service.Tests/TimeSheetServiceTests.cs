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
    public class TimeSheetServiceTests
    {
        [Fact]
        public void AddNewEventShouldAddEventInDatabase()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "TimeSheet_AddEvent_Database")
                .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var newEvent = new DailyAgenda
            {
                Description = "Nice short description",
                Project = "New Project",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(1.1),
                ThemeColor = "red"
            };

            dbContext.DailyAgendas.Add(newEvent);
            dbContext.SaveChanges();

            var service = new TimeSheetService(dbContext);

            var actual = dbContext.DailyAgendas.FirstOrDefault(e => e.Id == newEvent.Id);

            Assert.Equal(newEvent.Project, actual.Project);
            Assert.Equal(newEvent.Description, actual.Description);
            Assert.Equal(newEvent.StartDate, actual.StartDate);
            Assert.Equal(newEvent.EndDate, actual.EndDate);
            Assert.Equal(newEvent.ThemeColor, actual.ThemeColor);
        }

        [Fact]
        public void GetEventFromIdShouldReturnCorrectEvent()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                                .UseInMemoryDatabase(databaseName: "TimeSheet_GetEventById_Database")
                                .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var newEvent = new DailyAgenda
            {
                Description = "Nice short description",
                Project = "New Project",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(1.1),
                ThemeColor = "red"
            };

            dbContext.DailyAgendas.Add(newEvent);
            dbContext.SaveChanges();

            var service = new TimeSheetService(dbContext);

            var actual = service.GetEventFromId(newEvent);

            Assert.Equal(newEvent, actual);
        }

        [Fact]
        public void GetAllEventsOfUserFromDBShouldReturnCorrectEvents()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                    .UseInMemoryDatabase(databaseName: "TimeSheet_GetAllEventByUserId_Database")
                    .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var newEvent = new DailyAgenda
            {
                Description = "Nice short description",
                Project = "New Project",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(1.1),
                ThemeColor = "red"
            };

            var newEvent2 = new DailyAgenda
            {
                Description = "Nice short description",
                Project = "New Project 2",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(1.1),
                ThemeColor = "red"
            };

            var user = new ApplicationUser
            {
                Email = "pesho@abv.bg",
                FullName = "Pesho"
            };

            user.DailyAgendas.Add(newEvent);
            user.DailyAgendas.Add(newEvent2);

            dbContext.DailyAgendas.Add(newEvent);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var service = new TimeSheetService(dbContext);

            var actual = service.GetAllEventsOfUserFromDB(user.Id);

            Assert.Equal(2, actual.Count());
        }

        [Fact]
        public void DeleteEventFromDbShouldDeleteCorrectEvent()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
        .UseInMemoryDatabase(databaseName: "TimeSheet_DeleteEvent_Database")
        .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var newEvent = new DailyAgenda
            {
                Description = "Nice short description",
                Project = "New Project",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(1.1),
                ThemeColor = "red"
            };

            dbContext.DailyAgendas.Add(newEvent);
            dbContext.SaveChanges();

            var service = new TimeSheetService(dbContext);

            service.DeleteEventFromDb(newEvent.Id);

            dbContext.SaveChanges();

            var actual = dbContext.DailyAgendas.Count();

            Assert.Equal(0, actual);
        }
    }
}
