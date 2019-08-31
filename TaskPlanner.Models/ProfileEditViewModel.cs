using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskPlanner.Data.Models;
using TaskPlanner.Infrastructure;

namespace TaskPlanner.ViewModels
{
    public class ProfileEditViewModel : IMapFrom<ApplicationUser>
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

        public string Images { get; set; }
    }
}
