using Microsoft.AspNetCore.Mvc;
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

        public void AddNewEvent(DailyAgenda dailyAgenda)
        {
            this.dbContext.DailyAgendas.Add(dailyAgenda);
        }

        public DailyAgenda GetEventFromId(DailyAgenda dailyAgenda)
        {
            var result = this.dbContext.DailyAgendas.Where(d => d.Id == dailyAgenda.Id).FirstOrDefault();
            return result;
        }

        public IEnumerable<DailyAgenda> GetAllEventsFromDB()
        {
            var events = this.dbContext.DailyAgendas.ToList();

            return events;
        }

        public void UpdateDatabase()
        {
            this.dbContext.SaveChanges();
        }

        public void DeleteEventFromDb(string eventId)
        {
            var eventTarget = this.dbContext.DailyAgendas.Where(e => e.Id == eventId).FirstOrDefault();
            if (eventTarget != null)
            {
                this.dbContext.DailyAgendas.Remove(eventTarget);
            }
        }
    }
}
