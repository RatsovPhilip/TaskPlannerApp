namespace TaskPlanner.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using TaskPlanner.CustomValidationAttributes;

    public class CompanyJoinCheckNameViewModel
    {
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(50)]
        [CheckCompanyNameJoin]
        public string Name { get; set; }
    }
}
