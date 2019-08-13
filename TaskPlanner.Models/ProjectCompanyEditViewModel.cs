using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.ViewModels
{
    public class ProjectCompanyEditViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
