using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.ViewModels
{
    public class ProjectCategoryAddViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
