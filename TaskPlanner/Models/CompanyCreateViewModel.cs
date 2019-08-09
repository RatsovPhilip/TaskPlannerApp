using System.ComponentModel.DataAnnotations;
using TaskPlanner.CustomValidationAttributes;
using TaskPlanner.Data.Models;
using TaskPlanner.Infrastructure;

namespace TaskPlanner.Models
{
    public class CompanyCreateViewModel : IMapFrom<Company>
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
