using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Models
{
    public class CompanyProjectViewModel
    {
        public CompanyProjectViewModel()
        {
            this.ProjectsName = new List<ProjectViewModel>();
        }

        public List<ProjectViewModel> ProjectsName { get; set; }
    }
}
