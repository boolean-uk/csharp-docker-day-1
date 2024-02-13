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
        {   modelBuilder.Entity<Student>().HasKey(x => x.Id);  
            modelBuilder.Entity<Student>()
                        .HasOne(x => x.Course)
                        .WithMany(c => c.Students)
                        .HasForeignKey(x => x.CourseId);
            modelBuilder.Entity<Course>().HasKey(x => x.Id);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
