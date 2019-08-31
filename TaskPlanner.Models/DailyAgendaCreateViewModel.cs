namespace TaskPlanner.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Data.Models.Enums;
    using Infrastructure;

    public class DailyAgendaViewModel : IMapFrom<DailyAgenda>
    {
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Project { get; set; }

        public SubCategory SubCategory { get; set; }

        [MinLength(5)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string ThemeColor { get; set; }

    }
}
