using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.CustomValidationAttributes;

namespace TaskPlanner.Models
{
    public class CompanyJoinModel
    {
        [Required]
        [MaxLength(50)]
        [CheckCompanyNameJoin]
        public string Name { get; set; }
    }
}
