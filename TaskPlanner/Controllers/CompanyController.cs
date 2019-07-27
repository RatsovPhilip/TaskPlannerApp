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
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public CompanyController(ICompanyService companyService, IUserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.companyService = companyService;
            this.userService = userService;
            this.userManager = userManager;
            this.roleManager = roleManager;
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
                var user = await this.userManager.GetUserAsync(this.User);

                var company = new Company
                {
                    Name = companyModel.Name
                };

                this.companyService.CreateCompany(company, user);

                if (!await roleManager.RoleExistsAsync(GlobalConstants.RoleAdmin))
                {
                    await this.roleManager.CreateAsync(new IdentityRole() { Name = GlobalConstants.RoleAdmin });
                }

                await this.userManager.AddToRoleAsync(user, GlobalConstants.RoleAdmin);

                return Redirect("/");
            }


            return this.View();
        }

    }
}
