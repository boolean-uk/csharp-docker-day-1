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
                new Student()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Birthdate = new DateTime(2000, 1, 15).ToUniversalTime(),
                    CourseTitle = "Computer Science",
                    CourseStartDate = new DateTime(2023, 9, 1).ToUniversalTime(),
                    AverageGrade = 3.5f
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Birthdate = new DateTime(1999, 5, 22).ToUniversalTime(),
                    CourseTitle = "Mathematics",
                    CourseStartDate = new DateTime(2023, 9, 1).ToUniversalTime(),
                    AverageGrade = 3.8f

                }
                );

        }
        public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
    }
}
