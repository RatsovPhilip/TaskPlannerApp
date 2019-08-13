using System.Collections.Generic;

namespace TaskPlanner.ViewModels
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
