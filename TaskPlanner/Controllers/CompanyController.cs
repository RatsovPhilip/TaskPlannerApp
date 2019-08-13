using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Service;
using TaskPlanner.Service.Common;
using TaskPlanner.ViewModels;
using TaskPlanner.Web.Models;

namespace TaskPlanner.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IProjectService projectService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CompanyController(ICompanyService companyService, IProjectService projectService, IUserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.companyService = companyService;
            this.projectService = projectService;
            this.userService = userService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreateCheckNameViewModel companyModel)
        {
            if (ModelState.IsValid)
            {
                var companyBinding = new CompanyCreateViewModel
                {
                    Name = companyModel.Name,
                    Address = companyModel.Address,
                    FieldOfService = companyModel.FieldOfService
                };

                var userId = this.userManager.GetUserId(this.User);

                var userFromDb = this.userService.GetCurrentUserFromDb(userId);

                this.companyService.CreateCompany(companyBinding, userFromDb);

                if (!await roleManager.RoleExistsAsync(GlobalConstants.RoleAdmin))
                {
                    await this.roleManager.CreateAsync(new IdentityRole() { Name = GlobalConstants.RoleAdmin });
                }

                await this.userManager.AddToRoleAsync(userFromDb, GlobalConstants.RoleAdmin);
                await this.signInManager.SignOutAsync();

                return Redirect("/Identity/Account/Login");
            }
            return this.View();
        }

        public IActionResult Join()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Join(CompanyJoinModel companyModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.userManager.GetUserId(this.User);

                var userFromDb = this.userService.GetCurrentUserFromDb(userId);

                this.companyService.JoinCompany(userFromDb, companyModel.Name);

                return Redirect("/");
            }
            return this.View();
        }
    }
}
