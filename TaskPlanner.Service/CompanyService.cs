namespace TaskPlanner.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Common;
    using ViewModels;

    public class CompanyService : ICompanyService
    {
        private readonly TaskPlannerDbContext dbContext;
        private readonly IUserService userService;

        public CompanyService(TaskPlannerDbContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public bool CheckIfCompanyNameIsAvailable(string name)
        {
            var companies = this.dbContext.Companies.Select(x => x.Name).ToList();

            foreach (var companyName in companies)
            {
                if (companyName == name)
                {
                    return false;
                }
            }

            return true;
        }

        public void CreateCompany(CompanyCreateViewModel company, ApplicationUser user)
        {

            var companyForAdd = new Company
            {
                Name = company.Name,
                FieldOfService = company.FieldOfService,
                Address = company.Address
            };

            user.CompanyName = companyForAdd.Name;
            user.IsPromoted = true;
            companyForAdd.TeamMembers.Add(user);
            this.AddCompanyDefaultProjects(companyForAdd);

            this.dbContext.Companies.Add(companyForAdd);
            this.dbContext.SaveChanges();
        }

        public void JoinCompany(ApplicationUser user, string companyName)
        {
            var company = this.GetCompanyByName(companyName);
            user.CompanyName = companyName;
            company.TeamMembers.Add(user);
            this.dbContext.SaveChanges();

        }

        public Company GetCompanyByName(string companyName)
        {
            return this.dbContext.Companies.FirstOrDefault(c => c.Name == companyName);
        }

        private void AddCompanyDefaultProjects(Company company)
        {
            var categorySick = new Category { Name = GlobalConstants.AbsenceCategorySickLeave };
            var categoryHoliday = new Category { Name = GlobalConstants.AbsenceCategoryNationalHoliday };
            var categoryTimeForTime = new Category { Name = GlobalConstants.AbsenceCategoryTimeForTime };
            var categoryVacation = new Category { Name = GlobalConstants.AbsenceCategoryVacation };

            categorySick.CompanyCategories = new List<CompanyCategory>
            {
                new CompanyCategory
                {
                     Company = company,
                     Category = categorySick
                }
            };

            categoryHoliday.CompanyCategories = new List<CompanyCategory>
            {
                new CompanyCategory
                {
                     Company = company,
                     Category = categoryHoliday
                }
            };

            categoryTimeForTime.CompanyCategories = new List<CompanyCategory>
            {
                new CompanyCategory
                {
                     Company = company,
                     Category = categoryTimeForTime
                }
            };

            categoryVacation.CompanyCategories = new List<CompanyCategory>
            {
                new CompanyCategory
                {
                     Company = company,
                     Category = categoryVacation
                }
            };

            this.dbContext.Categories.Add(categorySick);
            this.dbContext.Categories.Add(categoryHoliday);
            this.dbContext.Categories.Add(categoryTimeForTime);
            this.dbContext.Categories.Add(categoryVacation);
        }

    }
}
