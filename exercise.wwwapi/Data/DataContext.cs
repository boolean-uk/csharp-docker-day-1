using exercise.wwwapi.DataModels;
using exercise.wwwapi.Data;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private static bool _migration;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if(!_migration)
            {
                this.Database.Migrate();
                _migration = true;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder seeder = new Seeder();

            modelBuilder.Entity<Student>().HasData(seeder.Students);
            modelBuilder.Entity<Course>().HasData(seeder.Courses);


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
