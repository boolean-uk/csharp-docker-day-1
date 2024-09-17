using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        //private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //_connectionString = configuration.GetValue<string>("ConnectionStrings:DockerPostgres")!;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData( new List<Student>
            {
                new Student { Id = 1, FirstName = "Ola", LastName = "Nordmann", DateOfBirth = DateTime.UtcNow, CourseId = 1 },
                new Student { Id = 2, FirstName = "Jonas", LastName = "Jonason", DateOfBirth = DateTime.UtcNow, CourseId = 1 },
                new Student { Id = 3, FirstName = "Nigel", LastName = "Sibbert", DateOfBirth = DateTime.UtcNow, CourseId = 2 },
                new Student { Id = 4, FirstName = "Donald", LastName = "Trump", DateOfBirth = DateTime.UtcNow, CourseId = 2 },
                new Student { Id = 5, FirstName = "Elon", LastName = "Musk", DateOfBirth = DateTime.UtcNow, CourseId = 2 }
            });

            modelBuilder.Entity<Course>().HasData(new List<Course>
            {
                new Course { Id = 1, Title = "Fullstack .NET Developer", StartDate = DateTime.UtcNow, AverageGrade = 4.0f },
                new Course { Id = 2, Title = "Fullstack .Java Developer", StartDate = DateTime.UtcNow, AverageGrade = 5.0f }
            });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
