using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Models;
using TaskPlanner.Service;
using TaskPlanner.Service.Common;

namespace TaskPlanner.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IProjectService projectService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CompanyController(ICompanyService companyService,IProjectService projectService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.companyService = companyService;
            this.projectService = projectService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreateViewModel companyModel)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();

                 var company = new Company
                {
                    Name = companyModel.Name,
                    FieldOfService = companyModel.FieldOfService,
                    Address = companyModel.Address
                };

                this.companyService.CreateCompany(company, user);

                if (!await roleManager.RoleExistsAsync(GlobalConstants.RoleAdmin))
                {
                    await this.roleManager.CreateAsync(new IdentityRole() { Name = GlobalConstants.RoleAdmin });
                }

                this.projectService.AddDefaultProjects(company);

                await this.userManager.AddToRoleAsync(user, GlobalConstants.RoleAdmin);
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
        public async Task<IActionResult> Join(CompanyJoinModel companyModel)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();

                this.companyService.JoinCompany(user,companyModel.Name);

                return Redirect("/");
            }
            return this.View();
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await this.userManager.GetUserAsync(this.User);
        }

    }
}
