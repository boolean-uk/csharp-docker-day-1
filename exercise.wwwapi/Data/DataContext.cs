using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
          /* var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString"); */
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Course course1 = new Course() { Id = 1, CourseTitle = "C#", StartDate = DateTime.UtcNow, AverageGrade = 5 };
            Course course2 = new Course() { Id = 2, CourseTitle = "React", StartDate = DateTime.UtcNow, AverageGrade = 6 };

            Student student1 = new Student() { Id = 1, FirstName = "Ali Haider", LastName = "Khan", DateOfBirth = DateTime.UtcNow, CourseId = 1 };
            Student student2 = new Student() { Id = 2, FirstName = "Ali Akbar Khan", LastName = "Khan", DateOfBirth= DateTime.UtcNow, CourseId = 2 };

            modelBuilder.Entity<Course>().HasData(course1, course2);
            modelBuilder.Entity<Student>().HasData(student1, student2);
            

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
