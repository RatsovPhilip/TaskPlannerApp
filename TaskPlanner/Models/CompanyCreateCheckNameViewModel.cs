namespace TaskPlanner.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using CustomValidationAttributes;

    public class CompanyCreateCheckNameViewModel
    {
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(50)]
        [CheckCompanyName]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field of service is required")]
        [MaxLength(50)]
        public string FieldOfService { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
