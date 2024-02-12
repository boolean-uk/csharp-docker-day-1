using exercise.wwwapi.DataModels.CourseModels;
using exercise.wwwapi.DataModels.StudentModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Add some sample courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Mathematics", Starts = DateTime.UtcNow },
                new Course { Id = 2, Title = "Physics", Starts = DateTime.UtcNow }
            );

            // Add some sample students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.UtcNow, AverageGrade = 85.5, CourseId = 1 },
                new Student { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = DateTime.UtcNow, AverageGrade = 78.2, CourseId = 2 }
            );
        }
    }
}
