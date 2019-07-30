using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Service;

namespace TaskPlanner.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService timeSheetService;

        public TimeSheetController(ITimeSheetService timeSheetService)
        {
            this.timeSheetService = timeSheetService;
        }
        public IActionResult Me()
        {
            return this.View();
        }

        public ActionResult GetEvents()
        {
            return new JsonResult(this.timeSheetService.GetEventsFromDB());
        }
    }
}
