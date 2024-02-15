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
                        DateOfBirth = new DateTime(2000, 01, 26, 12, 12, 12, DateTimeKind.Utc),
                        CourseId = 1
                    },
                    new Student(){
                        Id = 2,
                        FirstName = "First",
                        LastName = "Third",
                        DateOfBirth = new DateTime (2000, 06, 03, 12, 12, 12, DateTimeKind.Utc), 
                        CourseId = 2
                    },
                    new Student(){
                        Id = 3,
                        FirstName = "First",
                        LastName = "Fourth",
                        DateOfBirth = new DateTime(2000, 12, 15, 12, 12, 12, DateTimeKind.Utc), 
                        CourseId = 1
                    }
                }
                );
        }
        public void SeedCourses()
        {
            _modelBuilder.Entity<Course>().HasData(
                new List<Course>()
                {
                    new Course(){
                        Id = 1,
                        AverageGrade = 1,
                        CourseStartDate = new DateTime(2024, 01, 04, 12, 12, 12, DateTimeKind.Utc),
                        CourseTitle = "Title"
                    },
                    new Course(){
                        Id = 2,
                        AverageGrade = 3,
                        CourseStartDate = new DateTime(2024, 06, 15, 12, 12, 12, DateTimeKind.Utc),
                        CourseTitle = "Another Title"
                    },
                    new Course(){
                        Id = 3,
                        AverageGrade = 2,
                        CourseStartDate = new DateTime(2025, 01, 26, 12, 12, 12, DateTimeKind.Utc),
                        CourseTitle = "Yet another Title"
                    }
                }
                );
        }
    }
}
