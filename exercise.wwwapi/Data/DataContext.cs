using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.wwwapi.Data;

public class DataContext : DbContext
{
    private string _connectionString;
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.LogTo(message => Debug.WriteLine(message));

    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
}
