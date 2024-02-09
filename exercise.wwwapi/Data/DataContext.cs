using exercise.wwwapi.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasKey(a => new { a.StudentId, a.CourseId });
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Grigoris", LastName = "Karampis", DateOfBirth = "18-4-2006" },
                new Student { Id = 2, FirstName = "Hannelieke", LastName = "Hoogenboom", DateOfBirth = "15-4-2006" },
                new Student { Id = 3, FirstName = "Neomi", LastName = "Bes", DateOfBirth = "3-4-2002"},
                new Student { Id = 4, FirstName = "Quinten", LastName = "van Koeverden", DateOfBirth = "22-10-2005" }
                );
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, CourseTitle = "Theater", StartDate = "31-1-2024" },
                new Course { Id = 2, CourseTitle = "Science", StartDate = "28-1-2024"},
                new Course { Id = 3, CourseTitle = "Piano", StartDate = "2-2-2024"},
                new Course { Id = 4, CourseTitle = "Chess", StartDate = "5-2-2024" }
                );
            modelBuilder.Entity<Registration>().HasData(
                new Registration { Id = 1, CourseId = 4, StudentId = 1, AverageGrade = 8.5f },
                new Registration { Id = 2, CourseId = 1, StudentId = 2, AverageGrade = 9.3f },
                new Registration { Id = 3, CourseId = 1, StudentId = 3, AverageGrade = 8.8f },
                new Registration { Id = 4, CourseId = 2, StudentId = 4, AverageGrade = 7.5f },
                new Registration { Id = 5, CourseId = 2, StudentId = 1, AverageGrade = 9.5f },
                new Registration { Id = 1, CourseId = 3, StudentId = 2, AverageGrade = 8.6f }
                );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
