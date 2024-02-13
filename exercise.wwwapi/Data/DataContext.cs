using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DockerConnection")!;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<Student>().Navigation(x => x.Course).AutoInclude();
            modelBuilder.Entity<Course>().Navigation(x => x.Students).AutoInclude();

            Course course = new Course
            {
                Id = 1,
                CourseName = "Computer Science"
            };

            Student student = new Student
            {
                Id = 1,
                FirstName = "First",
                LastName = "Student",
                DateOfBirth = DateTime.UtcNow.AddYears(-20).Date,
                CourseId = 1,
                StartDate = DateTime.UtcNow.AddYears(-2).Date,
                AverageGrade = 7.5
            };

            modelBuilder.Entity<Student>().HasData(student);
            modelBuilder.Entity<Course>().HasData(course);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
