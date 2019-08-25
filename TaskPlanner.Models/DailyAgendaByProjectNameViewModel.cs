using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;
using TaskPlanner.Infrastructure;

namespace TaskPlanner.ViewModels
{
    public class DailyAgendaByProjectNameViewModel : IMapFrom<DailyAgenda>
    {
        public string Id { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
