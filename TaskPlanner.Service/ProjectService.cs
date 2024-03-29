﻿namespace TaskPlanner.Service
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using ViewModels;

    public class ProjectService : IProjectService
    {
        private readonly TaskPlannerDbContext dbContext;
        private readonly ICompanyService companyService;
        private readonly IUserService userService;

        public ProjectService(TaskPlannerDbContext dbContext, ICompanyService companyService, IUserService userService)
        {
            this.dbContext = dbContext;
            this.companyService = companyService;
            this.userService = userService;
        }
        public void AddProject(ProjectCategoryAddViewModel viewModel, string userId)
        {
            var user = this.userService.GetCurrentUserFromDb(userId);
            var companyName = user.CompanyName;
            var companyToAdd = this.companyService.GetCompanyByName(companyName);

            var categoryToAdd = new Category
            {
                Name = viewModel.Name
            };

            categoryToAdd.CompanyCategories = new List<CompanyCategory>
                 {
                   new CompanyCategory
                   {
                       Company = companyToAdd,
                       Category = categoryToAdd
                   }
                 };

            this.dbContext.Categories.Add(categoryToAdd);
            this.dbContext.SaveChanges();
        }

        public CompanyProjectViewModel GetAllCompanyProjects(string userId, CompanyProjectViewModel viewModel)
        {
            var user = this.userService.GetCurrentUserFromDb(userId);

            var companyName = user.CompanyName;

            var projectsCollection = this.dbContext.Categories
                .Where(c => c.CompanyCategories.All(cc => cc.Company.Name.Contains(companyName)))
                .ToList();

            var projects = Mapper.Map<List<ProjectViewModel>>(projectsCollection);

            viewModel.ProjectsName.AddRange(projects);

            return viewModel;
        }

        public void DeleteProjectById(string id)
        {
            var project = this.dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (project != null)
            {
                this.dbContext.Categories.Remove(project);
                this.dbContext.SaveChanges();
            }
        }

        public Category GetCategoryById(string id)
        {
            var projectFromDb = this.dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
            return projectFromDb;
        }

        public void UpdateEditedProject(ProjectViewModel viewModel)
        {
            var project = this.dbContext.Categories.FirstOrDefault(p => p.Id == viewModel.Id);
            project.Name = viewModel.Name;
            this.dbContext.SaveChanges();
        }

        public List<DailyAgenda> GetAllProjectsByProjectName(string projectName)
        {
            var projects = this.dbContext.DailyAgendas.Where(project => project.Project == projectName).ToList();

            return projects;
        }
    }
}
