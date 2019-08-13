using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.ViewModels
{
    public class CompanyJoinModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
