﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        public ProjectsController(UserManager<ApplicationUser> userManager, IProjectService projectService, IUserService userService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.userService = userService;
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

                this.projectService.AddProject(viewModel, userId);

                return this.Redirect("/");

            }

            return this.View();
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        public IActionResult Manage(CompanyProjectViewModel viewModel)
        {
            var userId = this.GetCurrentUserId();

            viewModel = this.projectService.GetAllCompanyProjects(userId, viewModel);

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        public IActionResult Delete(string id)
        {
            this.projectService.DeleteProjectById(id);

            return this.Redirect("/Projects/Manage");
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = this.projectService.GetCategoryById(id);

            if (project == null)
            {
                return NotFound();
            }

            return this.View(project);
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        [HttpPost]
        public IActionResult Edit(ProjectViewModel viewModel)
        {
            if (viewModel.Name != null)
            {
                this.projectService.UpdateEditedProject(viewModel);

                return this.Redirect("/Projects/Manage");
            }

            return View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.RoleAdmin)]
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = this.projectService.GetCategoryById(id);
            if (project == null)
            {
                return NotFound();
            }

            var userId = GetCurrentUserId();
            var user = this.userService.GetCurrentUserFromDb(userId);
            var currentCompanyName = user.CompanyName;

            var allUsersFromDb = this.userService.GetAllUsersFromDb();
            var employeesFromCompany = this.userService.GetAllUsersFromCompany(allUsersFromDb, currentCompanyName);

            var model = employeesFromCompany
                .Where(currentUser => currentUser.DailyAgendas.All(a => a.Project.Contains(project.Name)))
                .ToList();

            return this.View(model);
        }

        private string GetCurrentUserId()
        {
            return this.userManager.GetUserId(this.User);
        }
    }
}
