using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
