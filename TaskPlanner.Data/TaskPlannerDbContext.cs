namespace TaskPlanner.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class TaskPlannerDbContext : IdentityDbContext
    {

        public TaskPlannerDbContext(DbContextOptions<TaskPlannerDbContext> options) : base(options)
        {

        }
        public TaskPlannerDbContext()
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<DailyAgenda> DailyAgendas { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
