namespace TaskPlanner.ViewModels
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class ProfileEditPostViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(2)]
        public string CompanyName { get; set; }

        [Required]
        [MinLength(2)]
        public string FullName { get; set; }

        public bool IsPromoted { get; set; }

        public IFormFile Images { get; set; }
    }
}
