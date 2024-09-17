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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seeder
            modelBuilder.Entity<Course>().HasData
                (
                    new Course() { Id = 1, CourseTitle = "Math201"},
                    new Course() { Id = 2, CourseTitle = "Kitchen2001"}
                );

            modelBuilder.Entity<Student>().HasData
                (
                    new Student() { Id = 1, FirstName = "John", LastName = "Bravo", DateOfBirth = DateOnly.Parse("2000-09-06"), CourseId = 1, CourseStart = DateTime.UtcNow + TimeSpan.FromDays(4), AverageGrade = 4.2 },
                    new Student() { Id = 2, FirstName = "Thomas", LastName = "Flya", DateOfBirth = DateOnly.Parse("2003-10-06"), CourseId = 2, CourseStart = DateTime.UtcNow + TimeSpan.FromDays(5), AverageGrade = 2.2 },
                    new Student() { Id = 3, FirstName = "Melvin", LastName = "Linderud", DateOfBirth = DateOnly.Parse("1999-06-26"), CourseId = 2, CourseStart = DateTime.UtcNow + TimeSpan.FromDays(5), AverageGrade = 4.8 }
                );
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
