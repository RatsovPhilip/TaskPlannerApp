namespace TaskPlanner.Data.Models
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
            this.DailyAgendas = new HashSet<DailyAgenda>();
        }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public bool IsPromoted { get; set; }

        public virtual ICollection<DailyAgenda> DailyAgendas { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
