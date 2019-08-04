using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public interface IProjectService
    {
        void AddProject(Category category);

        IEnumerable<Category> GetAllCompanyProjects(string companyName);
    }
}
