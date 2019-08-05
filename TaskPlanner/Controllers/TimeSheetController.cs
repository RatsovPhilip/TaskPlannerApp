using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TaskPlanner.Data.Models;
using TaskPlanner.Models;
using TaskPlanner.Service;

namespace TaskPlanner.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService timeSheetService;
        private readonly IUserService userService;
        private readonly IProjectService projectService;
        private readonly UserManager<ApplicationUser> userManager;

        public TimeSheetController(ITimeSheetService timeSheetService, IUserService userService,IProjectService projectService, UserManager<ApplicationUser> userManager)
        {
            this.timeSheetService = timeSheetService;
            this.userService = userService;
            this.projectService = projectService;
            this.userManager = userManager;
        }
        public IActionResult Me(CompanyProjectViewModel viewModel)
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = this.userService.GetCurrentUser(userId);

            var projectCollection = this.projectService.GetAllCompanyProjects(user.CompanyName);

            foreach(var projectName in projectCollection)
            {
                viewModel.ProjectsName.Add(projectName.Name);
            }

            return this.View(viewModel);
        }

        public ActionResult GetEvents()
        {
            //Collecting all events of current User so they can be displayed on the calendar

            var userId = this.userManager.GetUserId(this.User);

            return new JsonResult(this.timeSheetService.GetAllEventsOfUserFromDB(userId));
        }

        [HttpPost]
        public ActionResult SaveEvent(DailyAgenda dailyAgenda)
        {
            var status = false;

            if (dailyAgenda.Id != null)
            {
                //Editing existing event
                var newEvent = this.timeSheetService.GetEventFromId(dailyAgenda);
                if (newEvent != null)
                {
                    newEvent.Project = dailyAgenda.Project;
                    newEvent.StartDate = dailyAgenda.StartDate;
                    newEvent.EndDate = dailyAgenda.EndDate;
                    newEvent.Description = dailyAgenda.Description;
                    newEvent.ThemeColor = dailyAgenda.ThemeColor;
                }
            }
            else
            {
                //Adding new event

                //First adding the created event to the current User collection "DailyAgendas"
                var userId = this.userManager.GetUserId(this.User);
                var user = this.userService.GetCurrentUser(userId);
                user.DailyAgendas.Add(dailyAgenda);

                //Adding the event
                this.timeSheetService.AddNewEvent(dailyAgenda);
            }

            this.timeSheetService.UpdateDatabase();
            status = true;

            return new JsonResult(new { status });
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            //Deleteing existing event from Database

            var status = false;

            this.timeSheetService.DeleteEventFromDb(id);
            this.timeSheetService.UpdateDatabase();
            status = true;

            return new JsonResult(new { status });
        }
    }
}
