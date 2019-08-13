using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.ViewModels
{
    public class DailyAgendaCreateViewModel
    {
        public string Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ThemeColor { get; set; }

    }
}
