using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        public static DataBuilder<Student> AddStudents(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Student>().HasData(
                            new Student()
                            {
                                Id = 1,
                                FirstName = "John",
                                LastName = "Doe",
                                DateOfBirth = DateTime.SpecifyKind(new DateTime(2000, 1, 15), DateTimeKind.Utc), // January 15, 2000                                
                                AvarageGrade = 3.5f,
                                CourseId = 1
                            },
                            new Student()
                            {
                                Id = 2,
                                FirstName = "Jane",
                                LastName = "Smith",
                                DateOfBirth = DateTime.SpecifyKind(new DateTime(1999, 5, 22), DateTimeKind.Utc), // May 22, 1999
                                AvarageGrade = 3.8f,
                                CourseId = 2
                            }

                            );
        }

        public static DataBuilder<Course> AddCourses(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Course>().HasData(
                new Course()
                {
                    Id = 1,
                    CourseName = "Introduction to Web Development",
                    TutorName = "Alex Johnson Stone",
                    StartDate = DateTime.SpecifyKind(new DateTime(2024, 6, 15, 9, 0, 0), DateTimeKind.Utc), // June 15, 2024, 9:00 AM UTC
                    Capacity = 100,
                    Location = "Online"
                },
                new Course
                {
                    Id = 2,
                    CourseName = "Advanced C# Programming",
                    TutorName = "Maria Andersson",
                    StartDate = DateTime.SpecifyKind(new DateTime(2024, 6, 20, 13, 0, 0), DateTimeKind.Utc), // June 20, 2024, 1:00 PM UTC
                    Capacity = 30,
                    Location = "Fässberg" // Assuming 1 indicates a specific location in Sweden
                }

                );

        }
    }
}
