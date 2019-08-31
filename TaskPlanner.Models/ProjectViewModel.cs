namespace TaskPlanner.ViewModels
{
    using Data.Models;
    using Infrastructure;

    public class ProjectViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
