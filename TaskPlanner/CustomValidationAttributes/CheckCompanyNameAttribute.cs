using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Service;

namespace TaskPlanner.CustomValidationAttributes
{
    public class CheckCompanyNameAttribute : ValidationAttribute
    {
        private readonly ICompanyService companyService;

        public CheckCompanyNameAttribute(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var name = (string)value;

            if (!companyService.CheckIfCompanyNameIsAvailable(name))
            {
                return new ValidationResult($"Company name \"{validationContext.DisplayName}\" already exist");
            }

            if (string.IsNullOrEmpty(name))
            {
                return new ValidationResult($"Enter a valid name!");
            }

            return ValidationResult.Success;
        }
    }
}
