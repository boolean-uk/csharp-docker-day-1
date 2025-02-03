using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public static bool _migrations = false;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

            if (!_migrations)
            {
                
                this.Database.EnsureCreated();
                this.Database.Migrate();
                _migrations = true;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CoursePerson>().HasNoKey();
               //.HasKey(cp => new { cp.PersonId, cp.CourseId });

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Courses).WithMany(p => p.People)
                    .UsingEntity<CoursePerson>();
            
           

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursePerson> CoursePerson { get; set; }
        public DbSet<Office> Offices { get; set; }
    }
}
