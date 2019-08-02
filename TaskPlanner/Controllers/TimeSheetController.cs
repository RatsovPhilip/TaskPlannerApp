using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Data.Models;
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
            return new JsonResult(this.timeSheetService.GetAllEventsFromDB());
        }

        [HttpPost]
        public ActionResult SaveEvent(DailyAgenda dailyAgenda)
        {
            var status = false;

            if(dailyAgenda.Id != null)
            {
                var newEvent = this.timeSheetService.GetEventFromId(dailyAgenda);
                if (newEvent != null)
                {
                    newEvent.Subject = dailyAgenda.Subject;
                    newEvent.StartDate = dailyAgenda.StartDate;
                    newEvent.EndDate = dailyAgenda.EndDate;
                    newEvent.Description = dailyAgenda.Description;
                    newEvent.ThemeColor = dailyAgenda.ThemeColor;
                }
            }
            else
            {
                this.timeSheetService.AddNewEvent(dailyAgenda);
            }

            this.timeSheetService.UpdateDatabase();
            status = true;

            return new JsonResult(new { status });
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var status = false;

            this.timeSheetService.DeleteEventFromDb(id);
            this.timeSheetService.UpdateDatabase();
            status = true;

            return new JsonResult(new { status });
        }
    }
}
