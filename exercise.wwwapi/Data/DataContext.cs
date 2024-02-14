using exercise.wwwapi.Data.SeedData;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Navigation(s => s.Course).AutoInclude();
            modelBuilder.Entity<Course>().Navigation(c => c.Students).AutoInclude();

            Seeder seeder = new Seeder();
            modelBuilder.Entity<Course>().HasData(seeder.Courses);
            modelBuilder.Entity<Student>().HasData(seeder.Students);

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
