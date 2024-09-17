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
            Course course = new Course() {Id = 1, Title = "C# course", StartDate = DateTime.UtcNow };
            Course course2 = new Course() {Id = 2, Title = "C# course", StartDate = DateTime.UtcNow };
            Course course3 = new Course() {Id = 3, Title = "C# course", StartDate = DateTime.UtcNow };
            Course course4 = new Course() {Id = 4, Title = "C# course", StartDate = DateTime.UtcNow };
            Student student = new Student() {Id = 4, FirstName = "Magnus", LastName = "Brandsegg", CourseId = 1, DOB = DateTime.UtcNow};

            modelBuilder.Entity<Course>().HasData(course);
            modelBuilder.Entity<Student>().HasData(student);



        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
