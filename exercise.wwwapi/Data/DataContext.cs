using exercise.wwwapi.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
            /*
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            
            _connectionString = configuration.GetValue<string>("ConnectionStrings.ConnectionString")!;
            this.Database.EnsureCreated();
            */
            

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Grigoris", LastName = "Karampis", DateOfBirth = "18-4-2006", CourseTitle = "Science", AverageGrade = 9, StartDate = "31-8-2023" },
                new Student { Id = 2, FirstName = "Hannelieke", LastName = "Hoogenboom", DateOfBirth = "15-4-2006", CourseTitle = "Theater", AverageGrade = 7, StartDate = "31-8-2023" }
                );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
