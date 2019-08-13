using System.ComponentModel.DataAnnotations;
using TaskPlanner.CustomValidationAttributes;

namespace TaskPlanner.Web.Models
{
    public class CompanyJoinCheckNameViewModel
    {
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(50)]
        [CheckCompanyNameJoin]
        public string Name { get; set; }


    }
}
