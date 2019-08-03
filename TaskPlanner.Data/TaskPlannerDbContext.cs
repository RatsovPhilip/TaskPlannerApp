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
        public DbSet<CompanyCategory> CompanyCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CompanyCategory>()
    .HasKey(cc => new { cc.CompanyId, cc.CategoryId });

            builder.Entity<CompanyCategory>()
                .HasOne(cc => cc.Company)
                .WithMany(c => c.CompanyCategories)
                .HasForeignKey(cc => cc.CompanyId);

            builder.Entity<CompanyCategory>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.CompanyCategories)
                .HasForeignKey(cc => cc.CategoryId);

            base.OnModelCreating(builder);
        }
    }
}
