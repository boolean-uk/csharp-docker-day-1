using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public async Task<Student> GetStudentById(int id)
        {
            return _db.Students.Where(x =>  x.Id == id).FirstOrDefault();
        }

        public async Task<Student> DeleteStudent(Student student)
        {
           
            _db.Students.Remove(student);
            _db.SaveChanges();
            return student;
        }

        public async Task<Student> EditStudent(Student student, string name) {

            student.Name = name;
            _db.Students.Update(student);
            _db.SaveChanges();
            return student;
               }
    }
}
