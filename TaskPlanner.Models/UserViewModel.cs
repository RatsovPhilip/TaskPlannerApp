using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;
using TaskPlanner.Infrastructure;

namespace TaskPlanner.ViewModels
{
    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string FullName { get; set; }

        public bool IsPromoted { get; set; }
    }
}
