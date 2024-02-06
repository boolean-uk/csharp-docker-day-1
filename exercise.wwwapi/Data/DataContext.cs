using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Diagnostics;
using System.Reflection.Metadata;
using exercise.wwwapi.DataModels;


namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options): base(options) {

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            // optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Course>().HasMany(e => e.Students).WithOne(e => e.Course).HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>().HasData(
             new Course { Id = 1, Title = "Math", StartDate = DateTime.Now.ToUniversalTime() },
             new Course { Id = 2, Title = "Literature", StartDate = DateTime.Now.ToUniversalTime() },
             new Course { Id = 3, Title = "Arts", StartDate = DateTime.Now.ToUniversalTime() });


            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, FirstName = "Sandra", LastName = "Collins", DOB = DateTime.Now.ToUniversalTime(), CourseId = 1, AverageGrade = 3.0F });
            students.Add(new Student { Id = 2, FirstName = "Mike", LastName = "Smith", DOB = DateTime.Now.ToUniversalTime(), CourseId = 3, AverageGrade = 4.0F  });
            students.Add(new Student { Id = 3, FirstName = "Heather", LastName = "Dunst", DOB = DateTime.Now.ToUniversalTime(), CourseId = 2, AverageGrade = 5.0F  });

            modelBuilder.Entity<Student>().HasData(students);

        }




        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
