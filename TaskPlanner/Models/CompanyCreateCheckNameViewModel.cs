using System.ComponentModel.DataAnnotations;
using TaskPlanner.Web.CustomValidationAttributes;

namespace TaskPlanner.Web.Models
{
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
