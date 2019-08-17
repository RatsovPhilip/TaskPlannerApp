using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Service
{
    public interface IProjectService
    {
        void AddProject(ProjectCategoryAddViewModel viewModel,string userId);

        CompanyProjectViewModel GetAllCompanyProjects(string userId, CompanyProjectViewModel viewModel);

        void DeleteProjectById(string name);

        ProjectViewModel GetCategoryById(string id);

        void UpdateEditedProject(ProjectViewModel viewModel);
    }
}
