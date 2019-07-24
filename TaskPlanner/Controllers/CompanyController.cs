using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Data.Models;
using TaskPlanner.Models;
using TaskPlanner.Service;

namespace TaskPlanner.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public CompanyController(ICompanyService companyService, IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.companyService = companyService;
            this.userService = userService;
            this.userManager = userManager;
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CompanyCreateViewModel companyModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.userManager.GetUserId(this.User);
                var user = this.userService.GetCurrentUser(userId);

                var company = new Company
                {
                    Name = companyModel.Name

                };

                this.companyService.CreateCompany(company,user);

                return Redirect("/");
            }


            return this.View();
        }

    }
}
