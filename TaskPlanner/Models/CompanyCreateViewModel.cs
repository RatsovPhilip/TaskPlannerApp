using System.ComponentModel.DataAnnotations;
using TaskPlanner.CustomValidationAttributes;

namespace TaskPlanner.Models
{
    public class CompanyCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        [CheckCompanyName]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string FieldOfService { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
