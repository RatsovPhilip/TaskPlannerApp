namespace TaskPlanner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using TaskPlanner.Data.Models.Enums;

    public class DailyAgenda
    {
        public DailyAgenda()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Categories = new HashSet<Category>();
        }

        public string Id { get; set; }

        public string Project { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ThemeColor { get; set; }

        public SubCategory SubCategory { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
