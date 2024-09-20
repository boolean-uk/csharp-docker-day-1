using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionSting;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionSting = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDetails>()
                .HasKey(key => new { key.StudentId, key.CourseId });

            modelBuilder.Entity<CourseDetails>()
                .HasOne(cd => cd.Student)
                .WithMany(s => s.CourseDetails)
                .HasForeignKey(cd => cd.StudentId);


            modelBuilder.Entity<CourseDetails>()
                .HasOne(cd => cd.Course)
                .WithMany(c => c.CourseDetails)
                .HasForeignKey(cd => cd.CourseId);

            Seeder seeder = new Seeder();

            modelBuilder.Entity<Student>().HasData(seeder.Students);
            modelBuilder.Entity<Course>().HasData(seeder.Courses);
            modelBuilder.Entity<CourseDetails>().HasData(seeder.Details);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionSting);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetails> CoursesDetails { get; set; }
    }
}
