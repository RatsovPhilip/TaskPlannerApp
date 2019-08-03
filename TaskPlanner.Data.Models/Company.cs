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
            this.CompanyCategories = new HashSet<CompanyCategory>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string FieldOfService { get; set; }

        public string Address { get; set; }

        public ICollection<ApplicationUser> TeamMembers { get; set; }

        public ICollection<CompanyCategory> CompanyCategories { get; set; }

    }
}
