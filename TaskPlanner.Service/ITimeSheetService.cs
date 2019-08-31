namespace TaskPlanner.Service
{
    using System.Collections.Generic;
    using Data.Models;

    public interface ITimeSheetService
    {
        List<DailyAgenda> GetAllEventsOfUserFromDB(string userId);

        DailyAgenda GetEventFromId(DailyAgenda dailyAgenda);

        void DeleteEventFromDb(string eventId);

        void AddNewEvent(DailyAgenda dailyAgenda);

        void UpdateDatabase();
    }
}
