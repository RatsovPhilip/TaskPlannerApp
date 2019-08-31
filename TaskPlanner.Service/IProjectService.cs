namespace TaskPlanner.Service
{
    using System.Collections.Generic;
    using Data.Models;
    using ViewModels;

    public interface IProjectService
    {
        void AddProject(ProjectCategoryAddViewModel viewModel,string userId);

        CompanyProjectViewModel GetAllCompanyProjects(string userId, CompanyProjectViewModel viewModel);

        void DeleteProjectById(string name);

        Category GetCategoryById(string id);

        void UpdateEditedProject(ProjectViewModel viewModel);

        List<DailyAgenda> GetAllProjectsByProjectName(string projectName);
    }
}
