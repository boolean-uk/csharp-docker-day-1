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
    modelBuilder.Entity<Student>()
        .HasMany<Course>(s => s.Courses)
        .WithMany(c => c.Students)
        .UsingEntity<Dictionary<string, object>>(
            "student_courses",
            j => j.HasOne<Course>().WithMany().HasForeignKey("course_id"),
            j => j.HasOne<Student>().WithMany().HasForeignKey("student_id"),
            j =>
            {
                j.HasKey("student_id", "course_id");
                j.ToTable("student_courses");
            });

    modelBuilder.Entity<Student>()
        .HasIndex(s => s.Email)
        .IsUnique();

    var students = new[]
    {
        new Student
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            Name = "John Doe",
            Email = "john@gmail.com"
        },
        new Student
        {
            Id = new Guid("00000000-0000-0000-0000-000000000002"),
            Name = "Jane Doe",
            Email = "jane@gmail.com"
        }
    };

    modelBuilder.Entity<Student>().HasData(students);

    modelBuilder.Entity<Course>().HasData(
        new Course
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            Name = "Math",
            Department = "Mathematics",
            Credits = 5
        },
        new Course
        {
            Id = new Guid("00000000-0000-0000-0000-000000000002"),
            Name = "Science",
            Department = "Science",
            Credits = 5
        }
    );

    modelBuilder.Entity("student_courses").HasData(
        new
        {
            student_id = new Guid("00000000-0000-0000-0000-000000000001"),
            course_id = new Guid("00000000-0000-0000-0000-000000000001")
        },
        new
        {
            student_id = new Guid("00000000-0000-0000-0000-000000000001"),
            course_id = new Guid("00000000-0000-0000-0000-000000000002")
        },
        new
        {
            student_id = new Guid("00000000-0000-0000-0000-000000000002"),
            course_id = new Guid("00000000-0000-0000-0000-000000000001")
        },
        new
        {
            student_id = new Guid("00000000-0000-0000-0000-000000000002"),
            course_id = new Guid("00000000-0000-0000-0000-000000000002")
        }
    );
}

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
