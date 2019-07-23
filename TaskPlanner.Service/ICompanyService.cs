using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data.Models;

namespace TaskPlanner.Service
{
    public interface ICompanyService
    {
        void CreateCompany(Company company);

        bool CheckIfCompanyNameIsAvailable(string name);
    }
}
