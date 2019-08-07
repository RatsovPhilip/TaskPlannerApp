using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Models;
using TaskPlanner.Service;
using TaskPlanner.Service.Common;

namespace TaskPlanner.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IUserService userService;
        private readonly ICompanyService companyService;

        public ProjectsController(UserManager<ApplicationUser> userManager, IProjectService projectService, IUserService userService, ICompanyService companyService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.userService = userService;
            this.companyService = companyService;
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        public IActionResult Add()
        {

            return this.View();
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        [HttpPost]
        public IActionResult Add(ProjectCategoryAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.userManager.GetUserId(this.User);
                var currentUser = this.userService.GetCurrentUser(userId);
                var companyName = currentUser.CompanyName;
                var companyToAdd = this.companyService.GetCompanyByName(companyName);


                var categoryToAdd = new Category
                { Name = viewModel.Name
                };

                categoryToAdd.CompanyCategories = new List<CompanyCategory>
                 {
                   new CompanyCategory
                   {
                       Company = companyToAdd,
                       Category = categoryToAdd
                   }
                 };

                this.projectService.AddProject(categoryToAdd);

                return this.Redirect("/");

            }

            return this.View();
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        public IActionResult Manage(CompanyProjectViewModel viewModel)
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = this.userService.GetCurrentUser(userId);

            var projectCollection = this.projectService.GetAllCompanyProjects(user.CompanyName);

            foreach (var projectName in projectCollection)
            {
                viewModel.ProjectsName.Add(projectName.Name);
            }

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        public IActionResult Delete(string id)
        {
            this.projectService.DeleteProjectByName(id);

            return this.Redirect("/Projects/Manage");
        }

        public IActionResult Edit(string name)
        {

        }

    }
}
