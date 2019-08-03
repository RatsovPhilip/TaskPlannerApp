using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Models;
using TaskPlanner.Service;

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

        public IActionResult Add()
        {

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(ProjectCategoryAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.userManager.GetUserId(this.User);
                var currentUser = this.userService.GetCurrentUser(userId);
                var companyName = currentUser.CompanyName;
                var companyToAdd = this.companyService.GetCompanyByName(companyName);


                var categoryToAdd = new Category { Name = viewModel.Name };

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

    }
}
