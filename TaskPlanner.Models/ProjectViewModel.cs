using TaskPlanner.Data.Models;
using TaskPlanner.Infrastructure;

namespace TaskPlanner.ViewModels
{
    public class ProjectViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
