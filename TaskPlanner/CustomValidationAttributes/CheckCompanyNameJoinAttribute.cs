namespace TaskPlanner.CustomValidationAttributes
{
    using System.ComponentModel.DataAnnotations;
    using Service;

    public class CheckCompanyNameJoinAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var companyService = (ICompanyService)validationContext
                         .GetService(typeof(ICompanyService));

            var name = (string)value;

            if (companyService.CheckIfCompanyNameIsAvailable(name))
            {
                return new ValidationResult($"The company name doesn't exist. Try again with different name.");
            }

            if (string.IsNullOrEmpty(name))
            {
                return new ValidationResult($"Enter a valid name!");
            }

            return ValidationResult.Success;
        }
    }
}
