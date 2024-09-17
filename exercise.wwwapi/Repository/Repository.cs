using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Payloads;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<CourseDTO>> GetCourses()
        {
            var courses =  await _db.Courses.ToListAsync();
            List<CourseDTO> courseDTOs = new List<CourseDTO>();
            foreach (var course in courses)
            {
                courseDTOs.Add(MakeCourseDTO(course));
            }
            return courseDTOs;
        }

        private CourseDTO MakeCourseDTO(Course course)
        {
            CourseDTO courseDTO = new CourseDTO();
            courseDTO.CourseTitle = course.CourseTitle;
            courseDTO.StartDateForCourse = course.StartDateForCourse;

            return courseDTO;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = await _db.Students.ToListAsync();
            List<StudentDTO> studentDTOs = new List<StudentDTO>();
            foreach (var student in students)
            {
                studentDTOs.Add(await MakeStudentDTO(student));
            }
            return studentDTOs;
        }

        private async Task<StudentDTO> MakeStudentDTO(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.FirstName = student.FirstName;
            studentDTO.LastName = student.LastName;
            studentDTO.DateOfBirth = student.DateOfBirth;
            foreach (var id in student.CourseIds)
            {
                var course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
                if (course != null)
                {
                    studentDTO.Courses.Add(MakeCourseDTO(course));
                }
            }
            
            studentDTO.AverageGrade = student.AverageGrade;

            return studentDTO;
        }

        public async Task<StudentDTO> GetStudent(int studentId)
        {
            var student =  _db.Students.FirstOrDefault(x => x.Id == studentId);
            if (student == null)
            {
                throw new Exception("Student does not exist");
            }
            return await MakeStudentDTO(student);
        }

        public async Task<StudentDTO> CreateStudent(StudentPayload payload)
        {
            if(payload.FirstName == null || payload.LastName == null || payload.FirstName == ""  || payload.LastName == ""
                || payload.DateOfBirth == null || payload.DateOfBirth == "" || payload.AverageGrade < 0)
            {
                throw new Exception("Invalid input!");
            }
            foreach (var id in payload.CourseIds)
            {
                var course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
                if (course == null)
                {
                    throw new Exception("Invalid input, course does not exist!");
                }

            }
            Student student = new Student();
            student.FirstName = payload.FirstName;
            student.LastName = payload.LastName;

            CultureInfo culture = CultureInfo.InvariantCulture;
            student.DateOfBirth = DateOnly.ParseExact(payload.DateOfBirth, "yyyy-MM-dd", culture);

            student.CourseIds = payload.CourseIds;
            student.AverageGrade = payload.AverageGrade;

            _db.Students.Add(student);
            await _db.SaveChangesAsync();       
            return await MakeStudentDTO(student);
        }

        public async Task<StudentDTO> UpdateStudent(int studentId, StudentPayload payload)
        {
            if (payload.FirstName == null || payload.LastName == null || payload.FirstName == "" || payload.LastName == ""
                || payload.DateOfBirth == null || payload.DateOfBirth == "" || payload.AverageGrade < 0)
            {
                throw new Exception("Invalid input!");
            }
            var student = _db.Students.FirstOrDefault(x => x.Id == studentId);
            if (student == null)
            {
                throw new Exception("Student does not exist");
            }
            student.FirstName = payload.FirstName;
            student.LastName = payload.LastName;

            CultureInfo culture = CultureInfo.InvariantCulture;
            student.DateOfBirth = DateOnly.ParseExact(payload.DateOfBirth, "yyyy-MM-dd", culture);

            student.CourseIds = payload.CourseIds;
            student.AverageGrade = payload.AverageGrade;

            await _db.SaveChangesAsync();

            return await MakeStudentDTO(student);
        }

        public async Task<StudentDTO> DeleteStudent(int studentId)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == studentId);
            if (student == null)
            {
                throw new Exception("Student does not exist");
            }
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return await MakeStudentDTO(student);
        }

        public async Task<CourseDTO> GetCourse(int courseId)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
            if (course == null)
            {
                throw new Exception("Course does not exist");
            }
            return MakeCourseDTO(course);
        }

        public async Task<CourseDTO> CreateCourse(CoursePayload payload)
        {
            if (payload.CourseTitle == null || payload.CourseTitle == ""
                || payload.StartDate == null || payload.StartDate == "")
            {
                throw new Exception("Invalid input!");
            }
            CultureInfo culture = CultureInfo.InvariantCulture;

            Course course = new Course();
            course.StartDateForCourse = DateOnly.ParseExact(payload.StartDate, "yyyy-MM-dd", culture);
            course.CourseTitle = payload.CourseTitle;

            _db.Courses.Add(course);
            await _db.SaveChangesAsync();

            return MakeCourseDTO(course);
        }

        public async Task<CourseDTO> UpdateCourse(int courseId, CoursePayload payload)
        {
            if (payload.StartDate == null || payload.StartDate == "" ||
                payload.CourseTitle == null || payload.CourseTitle == "")
            {
                throw new Exception("Invalid input!");
            }
            var course = _db.Courses.FirstOrDefault(x => x.Id == courseId);
            if (course == null)
            {
                throw new Exception("Course does not exist");
            }
            CultureInfo culture = CultureInfo.InvariantCulture;


            course.StartDateForCourse = DateOnly.ParseExact(payload.StartDate, "yyyy-MM-dd", culture);
            course.CourseTitle = payload.CourseTitle;

            await _db.SaveChangesAsync();

            return MakeCourseDTO(course);
        }

        public async Task<CourseDTO> DeleteCourse(int courseId)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
            if (course == null)
            {
                throw new Exception("Course does not exist");
            }
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return MakeCourseDTO(course);
        }
    }
}
