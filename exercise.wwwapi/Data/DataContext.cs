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

            Course course1 = new Course() { Id = 1, CourseTitle = "c#", CourseStart = DateTime.UtcNow};

            Student student1 = new Student()
            {
                Id = 1,
                FirstName = "Robert",
                LastName = "Grey",
                DateOfBirth = 1995,
                AvgGrade = 10,
                CourseId = 1
            };

            modelBuilder.Entity<Course>().HasData(course1);
            modelBuilder.Entity<Student>().HasData(student1);
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
