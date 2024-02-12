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
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
               .HasOne<Course>(s => s.Course)
               .WithMany(c => c.Students)
               .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany<Student>(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "A", LastName = "Aa", DateOfBirth = "1992-01-01", AvrageGrade = 5, CourseId = 1 },
                new Student { Id = 2, FirstName = "B", LastName = "Bb", DateOfBirth = "1992-02-02", AvrageGrade = 4, CourseId = 1 },
                new Student { Id = 3, FirstName = "C", LastName = "Cc", DateOfBirth = "1992-03-03", AvrageGrade = 3, CourseId = 2 },
                new Student { Id = 4, FirstName = "D", LastName = "Dd", DateOfBirth = "1992-04-04", AvrageGrade = 2, CourseId = 2 },
                new Student { Id = 5, FirstName = "E", LastName = "Aa", DateOfBirth = "1992-01-01", AvrageGrade = 5, CourseId = 3 },
                new Student { Id = 6, FirstName = "F", LastName = "Bb", DateOfBirth = "1992-02-02", AvrageGrade = 4, CourseId = 3 },
                new Student { Id = 7, FirstName = "G", LastName = "Cc", DateOfBirth = "1992-03-03", AvrageGrade = 3, CourseId = 4 },
                new Student { Id = 8, FirstName = "H", LastName = "Dd", DateOfBirth = "1992-04-04", AvrageGrade = 2, CourseId = 4 }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Music", StartDate = "2024-01-01" },
                new Course { Id = 2, Title = "Math", StartDate = "2024-01-01" },
                 new Course { Id = 3, Title = "Programming", StartDate = "2024-01-01" },
                new Course { Id = 4, Title = "Art", StartDate = "2024-01-01" }
            );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
