namespace TaskPlanner.Service.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System.Linq;
    using Data;
    using Data.Models;
    using ViewModels;
    using Xunit;

    public class ProjectServiceTests
    {
        [Fact]
        public void AddProjectShouldAddSuccessfullyProjects()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                  .UseInMemoryDatabase(databaseName: "Projects_AddProjects_Database")
                  .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var user = new ApplicationUser
            {
                Email = "user@abv.bg",
                FullName = "Pesho Peshev"
            };

            var company = new Company
            {
                Name = "DataCenter",
                Address = "asd",
                FieldOfService = "IT"
            };

            dbContext.Users.Add(user);
            dbContext.Companies.Add(company);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(u => u.GetCurrentUserFromDb(user.Id))
                .Returns((ApplicationUser)dbContext.Users.FirstOrDefault(x => x.Email == user.Email));

            var companyService = new Mock<ICompanyService>();
            companyService.Setup(c => c.GetCompanyByName(company.Name))
                .Returns(dbContext.Companies.FirstOrDefault(c => c.Name == company.Name));

            var projectService = new ProjectService(dbContext, companyService.Object, userService.Object);

            var projectModel = new ProjectCategoryAddViewModel
            {
                Name = "New Project"
            };

            projectService.AddProject(projectModel, user.Id);

            var project = dbContext.Categories.FirstOrDefault(c => c.Name == projectModel.Name);

            Assert.Equal(projectModel.Name, project.Name);
        }

        [Fact]
        public void DeleteProjectByIdShouldDeleteTheCorrectProject()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                                .UseInMemoryDatabase(databaseName: "Projects_DeleteProject_Database")
                                .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var project = new Category
            {
                Name = "New Project"
            };

            dbContext.Categories.Add(project);
            dbContext.SaveChanges();

            var projectService = new ProjectService(dbContext, null,null);

            projectService.DeleteProjectById(project.Id);

            var actual = dbContext.Categories.Count();

            Assert.Equal(0, actual);
        }

        [Fact]
        public void GetCategoryByIdShouldReturnCorrectCategory()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                    .UseInMemoryDatabase(databaseName: "Projects_GetCategoryById_Database")
                    .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var project = new Category
            {
                Name = "New Project"
            };

            dbContext.Categories.Add(project);
            dbContext.SaveChanges();

            var projectService = new ProjectService(dbContext, null, null);

           var actual =  projectService.GetCategoryById(project.Id);

            Assert.Equal(project.Id, actual.Id);
            Assert.Equal(project.Name, actual.Name);
        }

        [Fact]
        public void UpdateEditedProjectShouldUpdateCorrectly()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                                .UseInMemoryDatabase(databaseName: "Projects_UpdateCategory_Database")
                                .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var project = new Category
            {
                Name = "New Project"
            };

            dbContext.Categories.Add(project);
            dbContext.SaveChanges();

            var projectService = new ProjectService(dbContext, null, null);

            var newName = new ProjectViewModel
            {
                Id = project.Id,
                Name = "New Project Updated"
            };

            projectService.UpdateEditedProject(newName);

            var actual = dbContext.Categories.FirstOrDefault(c => c.Id == project.Id);

            Assert.Equal(newName.Name, actual.Name);
        }

        [Fact]
        public void GetAllProjectsByProjectNameShouldReturnCollectionOfAllProjectsWithSameName()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                            .UseInMemoryDatabase(databaseName: "Projects_GetAllProjects_Database")
                            .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var project = new DailyAgenda
            {
                
                Project = "New Project"
            };

            var project2 = new DailyAgenda
            {
                Project = "New Project"
            };

            var project3 = new DailyAgenda
            {
                Project = "New Project"
            };

            dbContext.DailyAgendas.AddRange(project,project2,project3);
            dbContext.SaveChanges();

            var projectService = new ProjectService(dbContext, null, null);

            var collection = projectService.GetAllProjectsByProjectName(project.Project);

            Assert.Equal(3,collection.Count());
        }
    }
}
