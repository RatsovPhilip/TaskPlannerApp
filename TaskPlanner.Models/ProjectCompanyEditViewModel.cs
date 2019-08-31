namespace TaskPlanner.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProjectCompanyEditViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
