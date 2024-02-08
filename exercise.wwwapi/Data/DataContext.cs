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
            //_connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            //this.Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_connectionString);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Course>().HasKey(c => new { c.Id });

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "marcus", LastName = "palm", DateOfBirth = "5 march 1998", Courses = new List<Course>() }
                );
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, CourseTitle = "Programming", CourseStartDate = "15 march 2023" , grade = 5},
                new Course { Id = 2, CourseTitle = "Art", CourseStartDate = "25 april 2046", grade = 7 },
                new Course { Id = 3, CourseTitle = "History", CourseStartDate = "6 july 2024", grade = 3 }
                );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
