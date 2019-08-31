namespace TaskPlanner.Service.Tests
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Data;
    using Data.Models;
    using ViewModels;
    using Xunit;

    public class CompanyServiceTests
    {
        [Fact]
        public void CheckIfCompanyNameIsAvailableShouldReturnTrueIfCompanyExist()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                              .UseInMemoryDatabase(databaseName: "Company_CheckCompanyName_Database")
                              .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var company = new Company
            {
                Name = "DataCenter",
                Address = "asd",
                FieldOfService = "IT"
            };

            dbContext.Companies.Add(company);

            var companyService = new CompanyService(dbContext, null);

            var result = companyService.CheckIfCompanyNameIsAvailable(company.Name);

            Assert.True(result);
        }

        [Fact]
        public void CreateCompanySouldCreateCompanyAndAddInDb()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                              .UseInMemoryDatabase(databaseName: "Company_CreateCompany_Database")
                              .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var companyModel = new CompanyCreateViewModel
            {
                Name = "DataCenter",
                Address = "asd",
                FieldOfService = "IT"
            };

            var user = new ApplicationUser
            {
                Email = "user@abv.bg",
                FullName = "Pesho Peshev"
            };


            var companyService = new CompanyService(dbContext, null);

            companyService.CreateCompany(companyModel, user);

            var company = dbContext.Companies.FirstOrDefault(x => x.Name == companyModel.Name);

            Assert.Equal(companyModel.Name, company.Name);
            Assert.Equal(companyModel.Address, company.Address);
            Assert.Equal(companyModel.FieldOfService, company.FieldOfService);
        }

        [Fact]
        public void GetCompanyByNameShouldReturnCorrectCompanyFromDb()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                  .UseInMemoryDatabase(databaseName: "Company_GetCompany_Database")
                  .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var company = new Company
            {
                Name = "DataCenter",
                Address = "asd",
                FieldOfService = "IT"
            };

            dbContext.Companies.Add(company);
            dbContext.SaveChanges();

            var companyService = new CompanyService(dbContext, null);

            var actual = companyService.GetCompanyByName(company.Name);

            Assert.Equal(company, actual);
        }

        [Fact]
        public void JoinCompanyShouldFillGivenUserCompanyNameProp()
        {
            var options = new DbContextOptionsBuilder<TaskPlannerDbContext>()
                  .UseInMemoryDatabase(databaseName: "Company_JoinCompany_Database")
                  .Options;

            var dbContext = new TaskPlannerDbContext(options);

            var company = new Company
            {
                Name = "DataCenter",
                Address = "asd",
                FieldOfService = "IT"
            };

            var user = new ApplicationUser
            {
                Email = "user@abv.bg",
                FullName = "Pesho Peshev"
            };

            dbContext.Companies.Add(company);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var companyService = new CompanyService(dbContext, null);

            companyService.JoinCompany(user, company.Name);

            var userFromDb = (ApplicationUser)dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            var actual = userFromDb.CompanyName;

            var companyFromDb = dbContext.Companies.FirstOrDefault(c => c.Name == company.Name);

            Assert.Equal(company.Name,actual);
            Assert.Single(companyFromDb.TeamMembers);
        }
    }
}
