using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
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

        public async Task<Course> CreateCourse(Course course)
        {
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            var target = await GetCourse(id);
            _db.Courses.Remove(target);
            await _db.SaveChangesAsync();
            return target;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var target = await GetStudent(id);
            _db.Students.Remove(target);
            await _db.SaveChangesAsync();
            return target;
        }

        private async Task<Student> GetStudent(int id)
        {
            var target = await _db.Students.FirstOrDefaultAsync(x => x.StudentId== id);
            return target;
        }

        public async Task<Course> GetCourse(int id)
        {
            var target = await _db.Courses.FirstOrDefaultAsync(x=> x.CourseId == id);
            return target;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            var targets = await _db.Courses.ToListAsync();

            if (targets.Count == 0)
                throw new InvalidOperationException("The list is empty.");


            return await _db.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Course> UpdateCourse(CreateCourseDTO createCourseDTO, int i)
        {
            var target = await GetCourse(i);
            if (target == null)
                throw new KeyNotFoundException(" The id does not return an element");

            target.CourseTitle = createCourseDTO.CourseTitle;
            target.AverageGrade = createCourseDTO.AverageGrade;
            target.StartDate = createCourseDTO.StartDate;
            await _db.SaveChangesAsync();
            return target;
        }

        public async Task<Student> UpdateStudent(CreateStudentDTO createStudentDTO, int id)
        {
            var target = await GetStudent(id);

            if (target == null)
                throw new KeyNotFoundException(" The id does not return an element");

            target.StartDate = createStudentDTO.StartDate;
            target.DateOfBirth = createStudentDTO.DateOfBirth;
            target.FirstName = createStudentDTO.FirstName;
            target.LastName  = createStudentDTO.LastName;
        
            await _db.SaveChangesAsync();
            return target;
        }
    }
}
