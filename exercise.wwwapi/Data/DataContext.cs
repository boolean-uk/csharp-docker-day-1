using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {

        //private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //_connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            //this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(_connectionString);
            //optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "John", LastName = "Doe", DoB = DateTime.Parse("2000-01-15"), AverageGrade = 85.5m, CourseId = 1 },
                new Student { Id = 2, FirstName = "Jane", LastName = "Smith", DoB = DateTime.Parse("1999-08-22"), AverageGrade = 78.2m, CourseId = 2 },
                new Student { Id = 3, FirstName = "Alex", LastName = "Johnson", DoB = DateTime.Parse("2001-03-10"), AverageGrade = 92.0m, CourseId = 3 },
                new Student { Id = 4, FirstName = "Emily", LastName = "Brown", DoB = DateTime.Parse("2002-05-05"), AverageGrade = 89.7m, CourseId = 1 },
                new Student { Id = 5, FirstName = "David", LastName = "Miller", DoB = DateTime.Parse("2000-11-18"), AverageGrade = 76.8m, CourseId = 2 },
                new Student { Id = 6, FirstName = "Olivia", LastName = "Taylor", DoB = DateTime.Parse("2001-09-30"), AverageGrade = 94.2m, CourseId = 3 },
                new Student { Id = 7, FirstName = "Michael", LastName = "Williams", DoB = DateTime.Parse("1999-04-03"), AverageGrade = 88.1m, CourseId = 1 },
                new Student { Id = 8, FirstName = "Sophia", LastName = "Jones", DoB = DateTime.Parse("2002-02-14"), AverageGrade = 79.5m, CourseId = 2 },
                new Student { Id = 9, FirstName = "William", LastName = "Davis", DoB = DateTime.Parse("2000-07-12"), AverageGrade = 91.3m, CourseId = 3 },
                new Student { Id = 10, FirstName = "Emma", LastName = "Clark", DoB = DateTime.Parse("2001-06-28"), AverageGrade = 82.4m, CourseId = 1 }
            );


            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, CourseTitle = "Introduction to Programming", CourseStartDate = DateTime.Parse("2024-02-06") },
                new Course { Id = 2, CourseTitle = "Web Development Basics", CourseStartDate = DateTime.Parse("2024-03-15") },
                new Course { Id = 3, CourseTitle = "Database Design Fundamentals", CourseStartDate = DateTime.Parse("2024-04-10") },
                new Course { Id = 4, CourseTitle = "Advanced C# Programming", CourseStartDate = DateTime.Parse("2024-05-20") },
                new Course { Id = 5, CourseTitle = "Responsive Web Design", CourseStartDate = DateTime.Parse("2024-06-05") }
            );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
