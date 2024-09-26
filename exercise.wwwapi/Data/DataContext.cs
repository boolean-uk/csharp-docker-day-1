using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
               new Course { Id = 1, Title = "Java", StartDate = DateTime.SpecifyKind(DateTime.Parse("2024-11-15T16:30:00Z"), DateTimeKind.Utc), AverageGrade = 8.2d }
            );

            modelBuilder.Entity<Student>().HasData(
               new Student { Id = 1, FirstName = "Julia", LastName = "Lindgren", DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("2001-09-18T16:30:00Z"), DateTimeKind.Utc), CourseId = 1}
            );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
