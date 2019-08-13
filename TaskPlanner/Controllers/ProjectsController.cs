using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskPlanner.Data.Models;
using TaskPlanner.Service;
using TaskPlanner.Service.Common;
using TaskPlanner.ViewModels;

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
                var userId = this.GetCurrentUserId();
                var currentUser = this.GetCurrentUserById(userId);
                var companyName = currentUser.CompanyName;
                var companyToAdd = this.companyService.GetCompanyByName(companyName);


                var categoryToAdd = new Category
                {
                    Name = viewModel.Name
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
            var userId = this.GetCurrentUserId();
            var user = GetCurrentUserById(userId);

            var projectCollection = this.projectService.GetAllCompanyProjects(user.CompanyName);

            foreach (var project in projectCollection)
            {
                viewModel.ProjectsName.Add(new ProjectViewModel {
                    Id = project.Id,
                    Name = project.Name
                });
            }

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        public IActionResult Delete(string id)
        {
            this.projectService.DeleteProjectByName(id);

            return this.Redirect("/Projects/Manage");
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectFromDb = this.projectService.GetCategoryById(id);

            if (projectFromDb == null)
            {
                return NotFound();
            }

            var project = Mapper.Map<ProjectViewModel>(projectFromDb);

            return this.View(project);
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        [HttpPost]
        public IActionResult Edit(ProjectViewModel viewModel)
        {
            var projectFromDb = this.projectService.GetCategoryById(viewModel.Id);

            if (viewModel.Name != null)
            {
                projectFromDb.Name = viewModel.Name;

                this.projectService.UpdateDatabase();

                return this.Redirect("/Projects/Manage");
            }

            return View(viewModel);
        }

        private string GetCurrentUserId()
        {
            return this.userManager.GetUserId(this.User);
        }

        private ApplicationUser GetCurrentUserById(string id)
        {
            return this.userService.GetCurrentUserFromDb(id);
        }

    }
}
