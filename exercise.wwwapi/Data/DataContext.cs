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
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(s => s.LastName).IsRequired().HasMaxLength(50);
                entity.Property(s => s.DOB).HasColumnType("date");
                entity.Property(s => s.AvgGrade);
                entity.Navigation(s => s.StudentCourses).AutoInclude();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Start).HasColumnType("date");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.StudentCourses)
                      .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                      .WithMany(c => c.StudentCourses)
                      .HasForeignKey(sc => sc.CourseId);

                entity.Navigation(sc => sc.Course).AutoInclude();
            });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set;}
    }
}
