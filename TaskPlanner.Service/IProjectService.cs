using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public interface IProjectService
    {
        void AddProject(Category category);

        void AddDefaultProjects(Company company);

        IEnumerable<Category> GetAllCompanyProjects(string companyName);

        void DeleteProjectByName(string name);

        Category GetCategoryById(string id);

        void UpdateDatabase();
    }
}
