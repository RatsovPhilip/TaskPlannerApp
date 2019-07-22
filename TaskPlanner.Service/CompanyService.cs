using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void CreateCompany(Company company)
        {
            var companies = this.dbContext.Companies.Select(x => x.Name).ToList();
            foreach(var companyName in companies)
            {
                if (companyName == company.Name)
                {
                    return;
                }
            }
            this.dbContext.Companies.Add(company);
            this.dbContext.SaveChanges();
        }
    }
}
