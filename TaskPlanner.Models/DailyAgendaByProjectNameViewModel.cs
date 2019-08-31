namespace TaskPlanner.ViewModels
{
    using Data.Models;
    using Infrastructure;

    public class DailyAgendaByProjectNameViewModel : IMapFrom<DailyAgenda>
    {
        public string Id { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
