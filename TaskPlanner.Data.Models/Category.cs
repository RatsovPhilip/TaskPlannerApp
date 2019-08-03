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
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public SubCategory SubCategory { get; set; }

        public ICollection<CompanyCategory> CompanyCategories { get; set; }
    }
}
