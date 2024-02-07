using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(x => new { x.Id });
            modelBuilder.Entity<Course>().HasKey(x => new { x.Id });
            modelBuilder.Entity<Join_student_course>().HasKey(x => new { x.StudentId, x.CourseId });

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Victor", LastName = "Adamson", DoB = "03/02-00", AvgGrade = 2},
                new Student { Id = 2, FirstName = "Person", LastName = "Human", DoB = "14/11-95", AvgGrade = 1},
                new Student { Id = 3, FirstName = "Beep", LastName = "NaN", DoB = "22/06-98", AvgGrade = 4}
            );
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = ".NET", Description = "A Boolean fullstack course about .NET",  StartDate = "08/01-24"},
                new Course { Id = 2, Title = "Java", Description = "A Boolean course about Java", StartDate = "08/01-24"}
            );
            List<Join_student_course> input = new List<Join_student_course>();
            input.Add(new Join_student_course { StudentId = 1, CourseId = 1 });
            input.Add(new Join_student_course { StudentId = 2, CourseId = 1 });
            input.Add(new Join_student_course { StudentId = 3, CourseId = 2 });
            input.Add(new Join_student_course { StudentId = 3, CourseId = 1 });

            modelBuilder.Entity<Join_student_course>().HasData(input);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Join_student_course> JoinStudents { get; set; }
    }
}
