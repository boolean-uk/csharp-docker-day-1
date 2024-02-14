using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private static bool _migrations;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (!_migrations)
            {
                this.Database.Migrate();
                _migrations = true;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Tom", LastName = "Hanks", DateOfBirth = DateTime.UtcNow, CreatedAt = DateTime.UtcNow },
                new Student { Id = 2, FirstName = "Lady", LastName = "Gaga", DateOfBirth = DateTime.UtcNow, CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "C# & .NET", StartDate = DateTime.UtcNow, AverageGrade = "A", CreatedAt = DateTime.UtcNow },
                new Course { Id = 2, Title = "Java", StartDate = DateTime.UtcNow, AverageGrade = "B", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Student>().Navigation(x => x.Course).AutoInclude();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
