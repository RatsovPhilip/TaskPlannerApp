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
            this.Project = new HashSet<Category>();
        }

        public string Id { get; set; }

        public ICollection<Category> Project { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ThemeColor { get; set; }
    }
}
