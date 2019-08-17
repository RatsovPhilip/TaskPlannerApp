using System.Collections.Generic;
using TaskPlanner.Data.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Service
{
    public interface ITimeSheetService
    {
        List<DailyAgendaViewModel> GetAllEventsOfUserFromDB(string userId);

        DailyAgenda GetEventFromId(DailyAgenda dailyAgenda);

        void DeleteEventFromDb(string eventId);

        void AddNewEvent(DailyAgenda dailyAgenda);

        void UpdateDatabase();
    }
}
