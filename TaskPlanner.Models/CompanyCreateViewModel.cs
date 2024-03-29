﻿namespace TaskPlanner.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure;

    public class CompanyCreateViewModel : IMapFrom<Company>
    {
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field of service is required")]
        [MaxLength(50)]
        public string FieldOfService { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
