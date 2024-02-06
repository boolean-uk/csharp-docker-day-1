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
        public async Task<Student?> GetStudent(int id)
        {
            if(id < 0)
            {
                return null;
            }
            return await _db.Students.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }
        public async Task<Student?> UpdateStudent(int id, string FirstName, string LastName, string Dob, string CourseTitle, string StartDate, int AvgGrade)
        {
            //Get student to be updated
            var student = await GetStudent(id);
            //Add update data to student
            student.FirstName = FirstName;
            student.LastName = LastName;
            student.DoB = Dob;
            student.CourseTitle = CourseTitle;
            student.StartDate = StartDate;
            student.AvgGrade = AvgGrade;
            //Return student with new data and save changes
            _db.SaveChanges();
            return student;
        }
        public async Task<Student> CreateStudent(string FirstName, string LastName, string Dob, string CourseTitle, string StartDate, int AvgGrade)
        {
            Student student = new Student();
            student.FirstName = FirstName;
            student.LastName = LastName;
            student.DoB = Dob;
            student.CourseTitle = CourseTitle;
            student.StartDate = StartDate;
            student.AvgGrade= AvgGrade;
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }
        public async Task<Student?> DeleteStudent(int id)
        {
            var student = await GetStudent(id);
            _db.Students.Remove(student);
            _db.SaveChanges(); 
            return student;
        }


        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }
    }
}
