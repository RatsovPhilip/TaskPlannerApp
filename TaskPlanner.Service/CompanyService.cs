using System.Linq;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly TaskPlannerDbContext dbContext;
        private readonly IProjectService projectService;

        public CompanyService(TaskPlannerDbContext dbContext, IProjectService projectService)
        {
            this.dbContext = dbContext;
            this.projectService = projectService;
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
            companyForAdd.TeamMembers.Add(user);
            this.projectService.AddDefaultProjects(companyForAdd);

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

    }
}
