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
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>().HasData
                (
                    new Course() { Id = 1, Name = "C#" },
                    new Course() { Id = 2, Name = "javaMFS" }
                );
            modelBuilder.Entity<Student>().HasData
                (
                    new Student() { FirstName = "Thomas", LastName = "Flier", CourseId = 1, AverageGrade = 6, DateOfBirth = DateOnly.Parse("2001-09-17"), Id = 1, CourseStart = DateTime.UtcNow},
                    new Student() { FirstName = "Melvin", LastName = "Utheeye", CourseId = 2, AverageGrade = 6, DateOfBirth = DateOnly.Parse("2001-08-25"), Id = 2, CourseStart = DateTime.UtcNow},
                    new Student() { FirstName = "Dennis", LastName = "Rizzah", CourseId = 1, AverageGrade = 6, DateOfBirth = DateOnly.Parse("2001-09-06"), Id = 3, CourseStart = DateTime.UtcNow}

                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
