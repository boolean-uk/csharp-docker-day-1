using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        //private string _connectionString;
        private static bool _migrations; 
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //_connectionString = configuration.GetValue<string>("ConnectionString:LocalDocker")!;
            if (!_migrations)
            {
                this.Database.Migrate();
                _migrations = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany()
                .UsingEntity(j => j.ToTable("StudentCourses"));

            modelBuilder.Entity<Student>().HasData(
                new Student{ Id = 1, FirstName = "John", LastName = "Doe", DoB = "1995-5-10" },
                new Student{ Id = 2, FirstName = "Alice", LastName = "Smith", DoB = "1998-8-15" },
                new Student{ Id = 3, FirstName = "Bob", LastName = "Johnson", DoB = "1997-3-25" },
                new Student{ Id = 4, FirstName = "Emily", LastName = "Brown", DoB = "1996-10-5" },
                new Student{ Id = 5, FirstName = "Michael", LastName = "Wilson", DoB = "1999-12-30" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course{ Id = 1, Title = "Mathematics", StartDate = "2024-8-10", AvgGrade = 'B' },
                new Course{ Id = 2, Title = "History", StartDate = "2023-10-15", AvgGrade = 'A' },
                new Course{ Id = 3, Title = "Science", StartDate = "2024-5-7", AvgGrade = 'C' },
                new Course{ Id = 4, Title = "Literature", StartDate = "2022-1-1", AvgGrade = 'B' },
                new Course{ Id = 5, Title = "Computer Science", StartDate = "2024-12-24", AvgGrade = 'A' }
            );
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
