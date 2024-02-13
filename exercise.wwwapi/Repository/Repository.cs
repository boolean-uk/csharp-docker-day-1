using AutoMapper;
using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IClass
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<T> Add(T input)
        {
           await _db.Set<T>().AddAsync(input);
            await _db.SaveChangesAsync();
            return input;
        }

        public async Task<T> DeleteById(int id)
        {
            T entity = await GetById(id);
            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateById(T input, int id)
        {
            T entity = await _db.Set<T>().FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("No id");
            //T entity = await GetById(id);
            _db.Attach(entity);
            _db.Entry(entity).CurrentValues.SetValues(input);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetById(int id) {
            T entity = await _db.Set<T>().FirstOrDefaultAsync(x => x.Id == id) ??
                throw new Exception("No id");
            return entity;
        }

        public async Task<Course> DeleteCourseById(int id)
        {
            Course entity = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("No id");

            _db.Remove(entity);
            // remove student with that course
            _db.Students.RemoveRange(_db.Students.Where(s => s.CourseId== entity.Id));
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
