using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<Course>().HasData(
                   new Course { Id = 1, Title = ".NET", StartDate = DateTime.SpecifyKind(DateTime.Parse("2024-11-15T16:30:00Z"), DateTimeKind.Utc), AverageGrade = 8.2f }
                );

                modelBuilder.Entity<Student>().HasData(
                   new Student { Id = 1, firstName = "Øyvind", lastName = "Onarheim", dateOfBirth = DateTime.SpecifyKind(DateTime.Parse("1995-06-03T16:30:00Z"), DateTimeKind.Utc), courseId = 1 }
                );

                base.OnModelCreating(modelBuilder);
            }
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
