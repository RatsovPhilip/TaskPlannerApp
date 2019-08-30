using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskPlanner.Data;
using TaskPlanner.Data.Models;
using TaskPlanner.ViewModels;

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

        public List<DailyAgenda> GetAllEventsOfUserFromDB(string userId)
        {
            var eventsFromDb = dbContext.DailyAgendas.Where(da => da.ApplicationUserId == userId).ToList();

            return eventsFromDb;
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
