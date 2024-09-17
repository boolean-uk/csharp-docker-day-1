using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
    }
}
