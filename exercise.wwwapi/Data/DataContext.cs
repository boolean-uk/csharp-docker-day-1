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
                new Student { Id = 1, Name = "Student1" },
                new Student { Id = 2, Name = "Student2" },
                new Student { Id = 3, Name = "Student3" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Course1" },
                new Course { Id = 2, Name = "Course2" },
                new Course { Id = 3, Name = "Course3" }
            );

            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { Id = 1, StudentId = 1, CourseId = 1 },
                new StudentCourse { Id = 2, StudentId = 2, CourseId = 2 },
                new StudentCourse { Id = 3, StudentId = 3, CourseId = 3 }
            );
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
