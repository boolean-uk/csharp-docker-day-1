using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder seeder = new Seeder();
            modelBuilder.Entity<Course>().HasData(seeder.Courses);
            modelBuilder.Entity<Student>().HasData(seeder.Students);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
