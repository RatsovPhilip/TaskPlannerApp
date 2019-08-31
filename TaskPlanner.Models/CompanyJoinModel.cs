namespace TaskPlanner.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CompanyJoinModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
