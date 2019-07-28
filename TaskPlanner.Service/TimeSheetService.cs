using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly TaskPlannerDbContext dbContext;

        public TimeSheetService(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<DailyAgenda> GetEventsFromDB()
        {
            var events = this.dbContext.DailyAgendas.ToList();

            return events;
        }
    }
}
