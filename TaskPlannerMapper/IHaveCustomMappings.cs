using AutoMapper;

namespace TaskPlanner.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression mapper);
    }
}
