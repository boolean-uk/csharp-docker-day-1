using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private DataContext _db;
        public StudentRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _db.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
        }


        public async Task<Student> Add(Student entity)
        {
            await _db.Students.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Student> Delete(int id)
        {
            var deletedStudent = await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
            _db.Students.Remove(deletedStudent);
            await _db.SaveChangesAsync();
            return deletedStudent;
        }

      
     
        public async Task<Student> Update(Student entity)
        {
            var updatedStudent = await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == entity.Id);
            updatedStudent.FirstName = entity.FirstName;
            updatedStudent.LastName = entity.LastName;
            updatedStudent.DoB = entity.DoB;
            updatedStudent.CourseId = entity.CourseId;
           
            await _db.SaveChangesAsync();
            
            return updatedStudent;
        }
    }
}
