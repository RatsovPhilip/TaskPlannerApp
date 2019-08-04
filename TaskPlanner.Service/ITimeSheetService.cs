﻿using System.Collections.Generic;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public interface ITimeSheetService
    {
        IEnumerable<DailyAgenda> GetAllEventsOfUserFromDB(string userId);

        DailyAgenda GetEventFromId(DailyAgenda dailyAgenda);

        void DeleteEventFromDb(string eventId);

        void AddNewEvent(DailyAgenda dailyAgenda);

        void UpdateDatabase();
    }
}
