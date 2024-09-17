using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Course> courses = new List<Course>()
            {
                new Course() {Id = 1, Title = "Java", StartDate = new DateOnly(2024, 08, 08), AvgGrade = 1.5},
                new Course() {Id = 2, Title = ".NET", StartDate = new DateOnly(2024, 08, 08), AvgGrade = 5.2}
            };

            List<Student> students = new List<Student>()
            {
                new Student() {Id = 1, FirstName = "Espen", LastName = "Luna", Birth = new DateOnly(2000,07, 20), CourseId = 2},
                new Student() {Id = 2, FirstName = "Eyvind", LastName = "Malde", Birth = new DateOnly(2000, 06, 26), CourseId = 2},
                new Student() {Id = 3, FirstName = "Daniel", LastName = "Røli", Birth = new DateOnly(2000, 10, 08), CourseId = 1}
            };

            modelBuilder.Entity<Course>().HasData(courses);    
            modelBuilder.Entity<Student>().HasData(students);

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
