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
            _connectionString = configuration.GetValue<string>("ConnectionString:LocalDocker")!;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder seeder = new();
            modelBuilder.Entity<Student>().HasData(seeder.Students);
            modelBuilder.Entity<Course>().HasData(seeder.Courses);

            modelBuilder.Entity<Student>().Navigation(x => x.Course).AutoInclude();
            modelBuilder.Entity<Course>().Navigation(x => x.Student).AutoInclude();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
