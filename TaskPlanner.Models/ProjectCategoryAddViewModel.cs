namespace TaskPlanner.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProjectCategoryAddViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
