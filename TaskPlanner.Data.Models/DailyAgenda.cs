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

        public DateTime Date { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
