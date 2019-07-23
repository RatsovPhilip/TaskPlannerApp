using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.CustomValidationAttributes;

namespace TaskPlanner.Models
{
    public class CompanyCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        [CheckCompanyName]
        public string Name { get; set; }
    }
}
