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
        public async Task<IEnumerable<CoursePayload>> GetCourses()
        {
            //Get courses
            var courses = await _db.Courses.Include(s => s.StudentCourses).ToListAsync();
            List<CoursePayload> result = new List<CoursePayload>();
            foreach (var course in courses)
            {
                result.Add(ConstructCoursePayload(course));
            }

            //Response
            return result;
        }
        private CoursePayload ConstructCoursePayload(Course course)
        {
            return new CoursePayload(course);
        }

        public async Task<IEnumerable<StudentPayload>> GetStudents()
        {
            //Get students
            var students = await _db.Students.Include(s => s.StudentCourses).ToListAsync();
            List<StudentPayload> result = new List<StudentPayload>();
            foreach (var student in students)
            {
                result.Add(ConstructStudentPayload(student));
            }

            //Response
            return result;
        }

        public async Task<StudentPayload> AddStudent(InputStudentDTO entity)
        {
            //Construct new student
            var student = new Student()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = DateOnly.ParseExact(entity.BirthDate, "yyyy-MM-dd")
            };

            //Add the student to database
            await _db.AddAsync(student);
            await _db.SaveChangesAsync();

            if (entity.CourseIds.Count > 0)
            {
                //Get the student
                var updateStudent = await _db.Students.Include(s => s.StudentCourses).Where(s => s.FirstName == entity.FirstName).Where(s => s.LastName == entity.LastName).FirstOrDefaultAsync();

                if (updateStudent != null)
                {
                    foreach (var id in entity.CourseIds)
                    {
                        if (_db.Courses.Where(c => c.Id == id).FirstOrDefault() != null)
                        {
                            updateStudent.StudentCourses.Add(new StudentCourse() { CourseId = id });
                        }
                    }

                    //Update the database
                    _db.Attach(updateStudent).State = EntityState.Modified;
                    await _db.SaveChangesAsync();

                    student = updateStudent;
                }
            }

            //Response
            return ConstructStudentPayload(student);
        }

        public async Task<StudentPayload> UpdateStudent(int id, InputStudentDTO entity)
        {
            var student = await _db.Students.Include(s => s.StudentCourses).Where(s => s.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            student.FirstName = entity.FirstName;
            student.LastName = entity.LastName;
            student.BirthDate = DateOnly.ParseExact(entity.BirthDate, "yyyy-MM-dd");
            student.StudentCourses.Clear();
            foreach (var courseId in entity.CourseIds)
            {
                if (_db.Courses.Where(c => c.Id == courseId).FirstOrDefault() != null)
                {
                    student.StudentCourses.Add(new StudentCourse() { CourseId = courseId });
                }
            }

            //Update the database
            _db.Attach(student).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            //Response
            return ConstructStudentPayload(student);
        }

        public async Task<StudentPayload> RemoveStudent(int id)
        {
            var student = await _db.Students.Include(s => s.StudentCourses).Where(s => s.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            //Remove student
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            //Response
            return ConstructStudentPayload(student);
        }


        private StudentPayload ConstructStudentPayload(Student student)
        {
            return new StudentPayload(student);
        }

    }
}
