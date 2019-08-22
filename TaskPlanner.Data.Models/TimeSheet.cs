namespace TaskPlanner.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class TimeSheet
    {
        public TimeSheet()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Schedule = new HashSet<DailyAgenda>();
        }
        public string Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<DailyAgenda> Schedule { get; set; }
    }
}
