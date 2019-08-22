namespace TaskPlanner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Enums;

    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CompanyCategories = new HashSet<CompanyCategory>();
            this.UsersCategories = new HashSet<UsersCategories>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CompanyCategory> CompanyCategories { get; set; }

        public virtual ICollection<UsersCategories> UsersCategories { get; set; }
    }
}
