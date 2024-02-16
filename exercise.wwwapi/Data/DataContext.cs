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
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, CourseTitle = "Mathematics", AverageGrade = 'B', StartDate = DateTime.UtcNow },
                new Course { Id = 2, CourseTitle = "Physics", AverageGrade = 'D', StartDate = DateTime.UtcNow.AddDays(-30) },
                new Course { Id = 3, CourseTitle = "Biology", AverageGrade = 'C', StartDate = DateTime.UtcNow.AddDays(-60) }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), CourseId= 1 },
                new Student { Id = 2, FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1999, 5, 10, 0, 0, 0, DateTimeKind.Utc), CourseId = 2 },
                new Student { Id = 3, FirstName = "Bob", LastName = "Johnson", DateOfBirth = new DateTime(2001, 8, 20, 0, 0, 0, DateTimeKind.Utc), CourseId = 3 },
                new Student { Id = 4, FirstName = "Charlie", LastName = "Brown", DateOfBirth = new DateTime(2002, 9, 30, 0, 0, 0, DateTimeKind.Utc), CourseId = 1 }
            );

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
