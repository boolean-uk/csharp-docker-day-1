using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(_connectionString);
            //optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(new Course()
            {
                Id = 1,
                Title = ".NET",
                StartTime = new DateTime(2024, 8, 08),
                AverageGrade = 9.7d,
            });

            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Abueg",
                DOB = new DateTime(2000, 8, 15),
                CourseId = 1,
            });
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
