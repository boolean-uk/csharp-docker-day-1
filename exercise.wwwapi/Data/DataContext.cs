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
            modelBuilder.Entity<Course>().HasData(new Course { Id = 1, Title = "Math", StartDate = DateTime.UtcNow, AvgGrade = 3 });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, FirstName = "Anders", LastName = "Ottersland", CourseID = 1, DOT = DateTime.UtcNow });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
