using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DockerConnectionString")!;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<Course>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
