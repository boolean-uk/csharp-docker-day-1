using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Sockets;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("Properties/appsettings.json").Build();
           // _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            _connectionString = configuration.GetValue<string>("ConnectionStrings:LocalConnection")!;

           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // For many to many:
            /*modelBuilder.Entity<Student>()
                .HasMany(s => s.Course)
                .WithMany(c => s.Student)
                .UsingEntity<StudentCourse>();*/

            // For many to one: !!!!If we have forreign Id as courseId.
            /* modelBuilder.Entity<Student>()
              .HasOne(s => s.Course)
             .WithMany(c => c.Students)
             .HasForeignKey(s => s.CourseId);*/

            //AUTO INCLUDE: 

            modelBuilder.Entity<Student>()
                .Navigation(s => s.Course)
                .AutoInclude();

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Naturdag", CourseStartDate = DateTime.Now },
                new Course { Id = 2, Title = "Matte", CourseStartDate = DateTime.Now },
                new Course { Id = 3, Title = "Fargerer", CourseStartDate = DateTime.Now },
                new Course { Id = 4, Title = "Kjeddeeeelig", CourseStartDate = DateTime.Now }
                );


           modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Idaa", LastName = "KK", DoB = DateTime.Parse("1998,1,2"), AverageGrade = 2.2, CourseId = 1 },
                new Student { Id = 2, FirstName = "DEW", LastName = "KK", DoB = DateTime.Parse("2002,1,2"), AverageGrade = 4.1, CourseId = 1 },
                new Student { Id = 3, FirstName = "Olkeee", LastName = "Bes", DoB = DateTime.Parse("2022,4,6"), AverageGrade = 6.0, CourseId = 2 },
                new Student { Id = 4, FirstName = "BAAAA", LastName = "Vor AD", DoB = DateTime.Parse("2002,5,5"), AverageGrade = 5.5, CourseId = 3 }
                );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
