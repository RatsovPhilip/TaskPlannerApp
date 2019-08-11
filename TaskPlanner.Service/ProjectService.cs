using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;
using TaskPlanner.Service.Common;

namespace TaskPlanner.Service
{
    public class ProjectService : IProjectService
    {
        private readonly TaskPlannerDbContext dbContext;

        public ProjectService(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddProject(Category category)
        {
            this.dbContext.Categories.Add(category);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAllCompanyProjects(string companyName)
        {
            var projects = this.dbContext.Categories
                .Where(c => c.CompanyCategories.All(cc => cc.Company.Name.Contains(companyName)))
                .ToList();

            return projects;
        }

        public void DeleteProjectByName(string name)
        {
            var project = this.dbContext.Categories.Where(c => c.Name == name).FirstOrDefault();
            if (project != null)
            {
                this.dbContext.Categories.Remove(project);
                this.dbContext.SaveChanges();
            }
        }

        public Category GetCategoryById(string id)
        {
            return this.dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateDatabase()
        {
            this.dbContext.SaveChanges();
        }

        public void AddDefaultProjects(Company company)
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
            this.dbContext.SaveChanges();
        }
    }
}
