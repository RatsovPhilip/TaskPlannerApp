using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Data.Models;
using TaskPlanner.Service;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IUserService userService,UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = this.userService.GetCurrentUserFromDb(userId);

            var model = Mapper.Map<UserViewModel>(user);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
