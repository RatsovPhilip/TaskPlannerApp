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

        List<ProjectViewModel> GetAllCompanyProjects(string userId);

        void DeleteProjectById(string name);

        ProjectViewModel GetCategoryById(string id);

        void UpdateEditedProject(ProjectViewModel viewModel);
    }
}
