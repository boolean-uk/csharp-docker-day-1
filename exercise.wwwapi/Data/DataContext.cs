using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>()
             .HasKey(cs => new { cs.StudentId, cs.CourseId });

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudent)
                .HasForeignKey(cs => cs.StudentId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudent)
                .HasForeignKey(cs => cs.CourseId);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
    }
}
