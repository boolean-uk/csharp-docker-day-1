using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = new Guid("1d73525f-87cf-4b0e-82e7-9943d285b26b"), Title = "Course 1" },
                new Course { Id = new Guid("2d73525f-87cf-4b0e-82e7-9943d285b26b"), Title = "Course 2" }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(2000, 1, 1), CourseTitle = "Course 1", StartDate = DateTime.Now, AverageGrade = 85.0, CourseId = new Guid("1d73525f-87cf-4b0e-82e7-9943d285b26b") },
                new Student { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(2001, 2, 2), CourseTitle = "Course 2", StartDate = DateTime.Now, AverageGrade = 90.0, CourseId = new Guid("2d73525f-87cf-4b0e-82e7-9943d285b26b")}
            );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
