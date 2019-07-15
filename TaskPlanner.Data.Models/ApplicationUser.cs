﻿namespace TaskPlanner.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
        }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

    }
}
