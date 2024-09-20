using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 1,
                FirstName = "Bjorg",
                LastName = "Kristiansen",
                DateOfBirth = new DateTime(1928, 9, 28),
                CourseId = 1
            });
            modelBuilder.Entity<Course>().HasData(new Course()
            {
                Id = 1,
                Title = ".NET Boolean Academy",
                StartsAt = new DateTime(2024, 8, 12),
                AverageGrade = 'A'
            });

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
