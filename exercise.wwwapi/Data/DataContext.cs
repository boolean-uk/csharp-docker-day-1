using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using exercise.wwwapi.DataModels;
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
            modelBuilder.Entity<Student>()
                .HasOne<Course>(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany<Student>(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);

            
            //Seed Students data
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = "1990-01-01", AvrageGrade = 5, CourseId = 1 },
                new Student { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = "1991-01-01", AvrageGrade = 4, CourseId = 1 },
                new Student { Id = 3, FirstName = "Sam", LastName = "Smith", DateOfBirth = "1992-01-01", AvrageGrade = 3, CourseId = 2 },
                new Student { Id = 4, FirstName = "Sara", LastName = "Smith", DateOfBirth = "1993-01-01", AvrageGrade = 2, CourseId = 2 }
            );

            //Seed Courses data
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Math", StartDate = "2021-01-01" },
                new Course { Id = 2, Title = "English", StartDate = "2021-01-01" }
            );


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
