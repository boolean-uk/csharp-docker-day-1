using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.SpecifyKind(new DateTime(2000, 1, 15), DateTimeKind.Utc), // January 15, 2000
                    CourseName = "Computer Science",
                    StartDateOfCourse = DateTime.SpecifyKind(new DateTime(2023, 9, 1), DateTimeKind.Utc), // September 1, 2023
                    AvarageGrade = 3.5f
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = DateTime.SpecifyKind(new DateTime(1999, 5, 22), DateTimeKind.Utc), // May 22, 1999
                    CourseName = "Mathematics",
                    StartDateOfCourse = DateTime.SpecifyKind(new DateTime(2023, 9, 1), DateTimeKind.Utc), // September 1, 2023
                    AvarageGrade = 3.8f
                }

                );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
