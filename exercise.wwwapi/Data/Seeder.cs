using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        private ModelBuilder _modelBuilder;
        public Seeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void SeedStudents()
        {
            _modelBuilder.Entity<Student>().HasData(
                new List<Student>()
                {   
                    new Student(){
                        Id = 1, 
                        FirstName = "First", 
                        LastName = "Second", 
                        DateOfBirth = new DateOnly(2000, 01, 26),
                        AverageGrade = 1, 
                        CourseStartDate = new DateOnly(2024, 01, 04), 
                        CourseTitle = "Title"
                    },
                    new Student(){
                        Id = 2,
                        FirstName = "First",
                        LastName = "Third",
                        DateOfBirth = new DateOnly(2000, 06, 03),
                        AverageGrade = 1,
                        CourseStartDate = new DateOnly(2024, 06, 15),
                        CourseTitle = "Another Title"
                    },
                    new Student(){
                        Id = 3,
                        FirstName = "First",
                        LastName = "Fourth",
                        DateOfBirth = new DateOnly(2000, 12, 15),
                        AverageGrade = 1,
                        CourseStartDate = new DateOnly(2025, 01, 26),
                        CourseTitle = "Yet another Title"
                    }
                }
                );
        }
    }
}
