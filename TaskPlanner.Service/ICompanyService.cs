namespace TaskPlanner.Service
{
    using Data.Models;
    using ViewModels;

    public interface ICompanyService
    {
        void CreateCompany(CompanyCreateViewModel company, ApplicationUser user);

        void JoinCompany(ApplicationUser user,string companyName);

        bool CheckIfCompanyNameIsAvailable(string name);

        Company GetCompanyByName(string companyName);

    }
}
