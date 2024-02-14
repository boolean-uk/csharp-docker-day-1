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
            modelBuilder.Entity<Student>().HasData(
       new Student { Id = 1, FirstName = "John", LastName = "Doe", BirthDate =
                    new DateTime(1995, 5, 15), CourseTitle = "Computer Science", StartDate = 
                    new DateTime(2022, 9, 1), AvgGrade = 85, CourseId = 1 },
       new Student { Id = 2, FirstName = "Alice", LastName = "Smith", BirthDate = 
                     new DateTime(1998, 10, 20), CourseTitle = "Mathematics", StartDate =
                    new DateTime(2022, 9, 1), AvgGrade = 90, CourseId = 2 }
        // Add more students as needed
   );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Computer Science" },
                new Course { Id = 2, Title = "Mathematics" }
                // Add more courses as needed
            );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
