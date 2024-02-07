using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        //private string _connectionString;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //_connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            //this.Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(e => new { e.Id, e.CourseId });
            modelBuilder.Entity<Course>().HasKey(e => new { e.Id });

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "English", StartDate = DateTime.Now.ToUniversalTime() },
                new Course { Id = 2, Title = "Swedish", StartDate = DateTime.Now.ToUniversalTime() },
                new Course { Id = 3, Title = "Math", StartDate = DateTime.Now.ToUniversalTime() }
                );

            List<Student> studentList = new List<Student>();
            studentList.Add(new Student { Id = 1, FirstName = "Klara", LastName = "Andersson", Birthday = "23/01", AverageGrade = "A", CourseId = 2 });
            studentList.Add(new Student { Id = 2, FirstName = "Daniella", LastName = "Hoff", Birthday = "23/10", AverageGrade = "C", CourseId = 1 });
            studentList.Add(new Student { Id = 3, FirstName = "Emelie", LastName = "Hogstedt", Birthday = "19/08", AverageGrade = "E", CourseId = 3 });
            modelBuilder.Entity<Student>().HasData(studentList);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}