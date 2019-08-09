using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Models;
using TaskPlanner.Infrastructure;

namespace TaskPlanner.Models
{
    public class ProjectViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
