using System;
using System.Collections.Generic;
using System.Text;

namespace TaskPlanner.Data.Models
{
    public class UsersCategories
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
