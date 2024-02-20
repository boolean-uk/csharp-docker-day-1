using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    
    public class DataContext : DbContext
    {
        private static bool _migrations;
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (!_migrations)
            {
                this.Database.Migrate();
                _migrations = true;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //key
            modelBuilder.Entity <Student>().Navigation(x => x.Course).AutoInclude();

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
