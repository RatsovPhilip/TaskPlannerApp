namespace TaskPlanner.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.TeamMembers = new HashSet<ApplicationUser>();
            this.Categories = new HashSet<Category>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string FieldOfService { get; set; }

        public string Address { get; set; }

        public ICollection<ApplicationUser> TeamMembers { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
