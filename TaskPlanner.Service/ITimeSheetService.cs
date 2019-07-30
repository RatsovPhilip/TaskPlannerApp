using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public interface ITimeSheetService
    {
        IEnumerable<DailyAgenda> GetEventsFromDB();
    }
}
