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
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DockerPostgres")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Course>().HasKey(x => x.Id);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
