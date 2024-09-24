using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString");
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
               new Student { Id = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(2000, 9, 19), CourseId = {1, 2} ,AverageGrade = 3 },
               new Student { Id = 2, FirstName = "Jane", LastName = "Smith", BirthDate = new DateOnly(1999, 5, 22), CourseId = new List<int> { 2, 3 }, AverageGrade = 4 },
               new Student { Id = 3, FirstName = "Robert", LastName = "Johnson", BirthDate = new DateOnly(2001, 12, 15), CourseId = new List<int> { 1, 3}, AverageGrade = 4}
                );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Programming", StartsAt = new DateOnly(2024, 8, 20) },
                new Course { Id = 2, Title = "Mathematics", StartsAt = new DateOnly(2024, 9, 1) },
                new Course { Id = 3, Title = "Physics", StartsAt = new DateOnly(2024, 9, 15) });

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
