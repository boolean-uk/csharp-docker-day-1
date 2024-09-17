using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
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
            //modelBuilder.Entity<Student>().

            Seeder seeder = new Seeder();

            modelBuilder.Entity<Student>().HasData(seeder.Students);
            modelBuilder.Entity<Course>().HasData(seeder.Courses);


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
