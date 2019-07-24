using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public interface ICompanyService
    {
        void CreateCompany(Company company, ApplicationUser user);

        bool CheckIfCompanyNameIsAvailable(string name);

    }
}
