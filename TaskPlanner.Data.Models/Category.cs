namespace TaskPlanner.Data.Models
{
    using System;
    using Enums;

    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public SubCategory SubCategory { get; set; }
    }
}
