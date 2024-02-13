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
            modelBuilder.Entity<Student>().Navigation(x => x.Course).AutoInclude();
            modelBuilder.Entity<Course>().Navigation(x => x.Students).AutoInclude();

            modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, AverageGrade = 90.5, StartDate = DateTime.UtcNow.AddMonths(-2), CourseName = "Programming 101" },
            new Course { Id = 2, AverageGrade = 85.0, StartDate = DateTime.UtcNow.AddDays(-2), CourseName = "Web Development Fundamentals" },
            new Course { Id = 3, AverageGrade = 88.2, StartDate = DateTime.UtcNow.AddMonths(-4), CourseName = "Data Structures and Algorithms" }
            );
            SeedStudents(modelBuilder);

        }
        private void SeedStudents(ModelBuilder modelBuilder)
        {
            Random random = new Random();

            for (int i = 1; i <= 50; i++)
            {
                var student = new Student
                {
                    Id = i,
                    FirstName = $"Student{i}",
                    LastName = $"Last{i}",
                    DateOfBirth = DateTime.UtcNow.AddYears(-20).AddDays(random.Next(1, 365)), // Assuming students are around 20 years old
                    CourseId = random.Next(1, 4) // Assign a random course (1, 2, or 3)
                };

                modelBuilder.Entity<Student>().HasData(student);
            }
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
