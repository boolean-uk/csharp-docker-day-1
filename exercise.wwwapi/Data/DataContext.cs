using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class DataContext : DbContext
{
    private string _connectionString;
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        _connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString")!;
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasKey(s => s.Id); //Primary key
        modelBuilder.Entity<Course>().HasKey(c => c.Id); //Primary key
        modelBuilder.Entity<Student>()
        .HasOne(s => s.Course) // Specify the navigation property
        .WithMany(c => c.Students) // Specify the inverse navigation property
        .HasForeignKey(s => s.CourseId);
        modelBuilder.Entity<Student>().HasData
            (
                new Student
                {
                    Id = 1,
                    FirstName = "Henrik",
                    LastName = "Rosenkilde",
                    DateOfBirth = "1998/11/29",
                    AverageGrade = 4,
                    CourseId = 1
                },

                new Student
                {
                    Id = 2,
                    FirstName = "Jens",
                    LastName = "Forgård",
                    DateOfBirth = "1999/03/15",
                    AverageGrade = 5,
                    CourseId = 1
                },

                new Student
                {
                    Id = 3,
                    FirstName = "Kristian",
                    LastName = "Verduin",
                    DateOfBirth = "1997/11/21",
                    AverageGrade = 6,
                    CourseId = 2
                }
            );

        modelBuilder.Entity<Course>().HasData
                (
                    new Course
                    {
                        Id = 1,
                        Title = "C#",
                        StartDate = "2024/08/07"
                    },

                    new Course
                    {
                        Id = 2,
                        Title = "C++",
                        StartDate = "2024/09/15"
                    }
                );
    }
}
