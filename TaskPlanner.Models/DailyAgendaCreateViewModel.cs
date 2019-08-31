using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Data.Models.Enums;
using TaskPlanner.Infrastructure;

namespace TaskPlanner.ViewModels
{
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
