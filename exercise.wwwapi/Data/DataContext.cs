using exercise.wwwapi.DataModels.CourseTypes;
using exercise.wwwapi.DataModels.StudentTypes;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.wwwapi.Data;

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
        modelBuilder.Entity<Student>().Navigation(s => s.Course).AutoInclude();

        modelBuilder.Entity<Course>().HasData(new List<Course>()
        {
            new Course() { Id = 1, Title = "C#", },
            new Course() { Id = 2, Title = "Java", },
        });
        modelBuilder.Entity<Student>().HasData(new List<Student>()
        {
            new Student() { Id = 1, FirstName = "Gudbrand", LastName = "Dynna", DateOfBirth = DateTime.SpecifyKind(new DateTime(2000, 7, 21), DateTimeKind.Utc),
                            CourseId = 1, AverageGrade = 3, StartDate = DateTime.SpecifyKind(new DateTime(2024, 1, 8), DateTimeKind.Utc)},
        });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(message => Debug.WriteLine(message));
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
}
