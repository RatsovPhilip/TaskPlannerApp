namespace TaskPlanner.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class DailyAgenda
    {
        public DailyAgenda()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Categories = new HashSet<Category>();
        }

        public string Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ThemeColor { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
