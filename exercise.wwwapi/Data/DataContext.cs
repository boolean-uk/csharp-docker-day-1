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
            modelBuilder.Entity<Student>().HasOne(s => s.Course).WithMany().HasForeignKey(s => s.CourseId);
        }
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Course> Courses { get; set; }
    }
}
