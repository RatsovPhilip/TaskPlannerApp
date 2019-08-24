using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Service
{
    public interface ICompanyService
    {
        void CreateCompany(CompanyCreateViewModel company, ApplicationUser user);

        void JoinCompany(ApplicationUser user,string companyName);

        bool CheckIfCompanyNameIsAvailable(string name);

        Company GetCompanyByName(string companyName);

    }
}
