using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Service;

namespace TaskPlanner.Controllers
{
    public class TimeSheet : Controller
    {
        private readonly ITimeSheetService timeSheetService;

        public TimeSheet(ITimeSheetService timeSheetService)
        {
            this.timeSheetService = timeSheetService;
        }
        public IActionResult Me()
        {
            return this.View();
        }

        public JsonResult GetEvents()
        {
            var events = this.timeSheetService.GetEventsFromDB();
            return Json(events);
        }
    }
}
