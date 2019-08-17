using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Data.Models.Enums;
using TaskPlanner.Infrastructure;

namespace TaskPlanner.ViewModels
{
    public class DailyAgendaViewModel : IMapFrom<DailyAgenda>
    {
        public string Id { get; set; }

        public string Project { get; set; }

        public SubCategory SubCategory { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ThemeColor { get; set; }

    }
}
