using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly TaskPlannerDbContext dbContext;

        public CompanyService(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public void CreateCompany(Company company,ApplicationUser user)
        {
            user.CompanyName = company.Name;
            company.TeamMembers.Add(user);
            this.dbContext.Companies.Add(company);
            this.dbContext.SaveChanges();
        }

        public Company GetCompanyByName(string companyName)
        {
            return this.dbContext.Companies.FirstOrDefault(c => c.Name == companyName);
        }
    }
}
