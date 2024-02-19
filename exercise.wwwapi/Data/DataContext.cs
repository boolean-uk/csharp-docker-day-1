using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public static bool _migrations;
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
            if(!_migrations)
            {
                this.Database.Migrate();
                _migrations = true;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Navigation(x => x.Course).AutoInclude();
            modelBuilder.Entity<Course>().Navigation(x => x.Students).AutoInclude();

            modelBuilder.Entity<Course>().HasData
                (
                    new Course { Id = 1, AvgGrade = 90.5, StartOfCourse = DateTime.UtcNow.AddMonths(-2), CourseName = "Programming 101" },
                    new Course { Id = 2, AvgGrade = 85.0, StartOfCourse = DateTime.UtcNow.AddDays(-2), CourseName = "Web Development Fundamentals" },
                    new Course { Id = 3, AvgGrade = 88.2, StartOfCourse = DateTime.UtcNow.AddMonths(-4), CourseName = "Data Structures and Algorithms" }
                );
            SeedStudents(modelBuilder);

        }

        private void SeedStudents(ModelBuilder modelBuilder)
        {
            Random random = new Random();

            for(int i = 1; i <= 30; i++)
            {
                var student = new Student  
                {
                    Id = i,
                    FirstName = $"Minion{i}",
                    LastName = $"Banana",
                    DateOfBirth = DateTime.UtcNow.AddYears(-200).AddDays(random.Next(1, 365)),
                    CourseId = random.Next(1, 4)
                };

                modelBuilder.Entity<Student>().HasData(student);
            }
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
