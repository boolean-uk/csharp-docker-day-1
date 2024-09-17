using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class CourseRepository(DataContext db) : IRepository<Course>
    {
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await db.Courses.ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return await db.Courses.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<Course> Add(Course entity)
        {
            await db.Courses.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;

        }

        public async Task<Course> Delete(int id)
        {
            var deletedCourse = await db.Courses.FirstOrDefaultAsync(c => c.Id == id);
            db.Courses.Remove(deletedCourse);
            await db.SaveChangesAsync();
            return deletedCourse;
        }

       

        public async Task<Course> Update(Course entity)
        {
            var updatedCourse = await db.Courses.FirstOrDefaultAsync(c => c.Id == entity.Id);
            updatedCourse.Title = entity.Title;
            updatedCourse.CourseStart = entity.CourseStart;
            updatedCourse.AverageGrade = entity.AverageGrade;

            await db.SaveChangesAsync();

            return updatedCourse;
        }
    }
}
    