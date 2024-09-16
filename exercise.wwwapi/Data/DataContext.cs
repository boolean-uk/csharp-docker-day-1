using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        //private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
           // optionsBuilder.UseNpgsql(_connectionString);
        //}
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
