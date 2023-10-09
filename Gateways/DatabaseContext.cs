using GatewayModels;
using Microsoft.EntityFrameworkCore;

namespace Gateways;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DatabaseContext()
    {
    }

    public DbSet<StudentEF> Students { get; set; }
    public DbSet<CourseEF> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseEF>().ToTable("Course");
        modelBuilder.Entity<StudentEF>().ToTable("Student");
    }
}
