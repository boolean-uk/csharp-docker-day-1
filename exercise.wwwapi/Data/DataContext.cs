using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Numerics;
using System.Xml;
using System.Security.Cryptography.X509Certificates;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
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
            modelBuilder.Entity<Student>().HasData
                (
                    new Student
                    {
                        Id = 1,
                        FirstName = "Joel",
                        LastName = "Joelsson",
                        DateOfBirth = "1994/02/07",
                        CourseTitle  = "Fundamentals of Csharp",
                        CourseStartDate = "2024/05/13",
                        AverageGrade = 4
                    },

                    new Student
                    {
                        Id = 2,
                        FirstName = "Anna",
                        LastName = "Andersson",
                        DateOfBirth = "1993/08/15",
                        CourseTitle = "Advanced Data Structures",
                        CourseStartDate = "2024/03/20",
                        AverageGrade = 5
                    },

                    new Student
                    {
                        Id = 3,
                        FirstName = "David",
                        LastName = "Davidsson",
                        DateOfBirth = "1995/11/21",
                        CourseTitle = "Machine Learning Fundamentals",
                        CourseStartDate = "2024/04/10",
                        AverageGrade = 3
                    },

                    new Student
                    {
                        Id = 4,
                        FirstName = "Emma",
                        LastName = "Emilsson",
                        DateOfBirth = "1992/06/30",
                        CourseTitle = "Web Development Basics",
                        CourseStartDate = "2024/06/01",
                        AverageGrade = 2
                    },

                    new Student
                    {
                        Id = 5,
                        FirstName = "Erik",
                        LastName = "Eriksson",
                        DateOfBirth = "1996/09/18",
                        CourseTitle = "Introduction to Algorithms",
                        CourseStartDate = "2024/02/15",
                        AverageGrade = 5
                    }
                );
        }
    }
}
