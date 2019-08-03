using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;

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
    }
}
