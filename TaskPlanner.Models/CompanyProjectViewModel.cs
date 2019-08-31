namespace TaskPlanner.ViewModels
{
    using System.Collections.Generic;

    public class CompanyProjectViewModel
    {
        public CompanyProjectViewModel()
        {
            this.ProjectsName = new List<ProjectViewModel>();
        }

        public List<ProjectViewModel> ProjectsName { get; set; }
    }
}
