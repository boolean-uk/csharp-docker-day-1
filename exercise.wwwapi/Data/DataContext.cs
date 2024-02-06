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
                new Course
                {
                    Id = 1,
                    Title = "Mathematics",
                    Description = "Advanced Calculus",
                    AvailableSpots = 30,
                    StartDate = DateTime.Now.AddDays(7).ToUniversalTime(),
                    EndDate = DateTime.Now.AddDays(120).ToUniversalTime(),
                },
                new Course
                {
                    Id = 2,
                    Title = "Computer Science",
                    Description = "Introduction to Programming",
                    AvailableSpots = 25,
                    StartDate = DateTime.Now.AddDays(14).ToUniversalTime(),
                    EndDate = DateTime.Now.AddDays(90).ToUniversalTime(),
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Birthdate = new DateTime(2000, 1, 15).ToUniversalTime(),
                    CourseId = 1,
                    AverageGrade = 3.5f
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Birthdate = new DateTime(1999, 5, 22).ToUniversalTime(),
                    CourseId = 2,
                    AverageGrade = 3.8f
                }
            );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
