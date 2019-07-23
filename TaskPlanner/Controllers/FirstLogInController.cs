using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Controllers
{
    public class FirstLogInController:Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
