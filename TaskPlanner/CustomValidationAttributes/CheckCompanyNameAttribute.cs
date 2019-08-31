namespace TaskPlanner.Web.CustomValidationAttributes
{
    using System.ComponentModel.DataAnnotations;
    using Service;

    public class CheckCompanyNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var companyService = (ICompanyService)validationContext
                         .GetService(typeof(ICompanyService));

            var name = (string)value;

            if (!companyService.CheckIfCompanyNameIsAvailable(name))
            {
                return new ValidationResult($"Company name already exist. Try different one.");
            }

            if (string.IsNullOrEmpty(name))
            {
                return new ValidationResult($"Enter a valid name!");
            }

            return ValidationResult.Success;
        }
    }
}
