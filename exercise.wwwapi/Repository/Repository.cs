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


        private CourseDTO MakeCourseDTO(Course course)
        {
            CourseDTO courseDTO = new CourseDTO();
            courseDTO.Title = course.Title;
            courseDTO.StartsAt = course.StartsAt;

            return courseDTO;
        }
        private async Task<StudentDTO> MakeStudentDTO(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.Id = student.Id;
            studentDTO.Name = student.FirstName + " " + student.LastName;
            studentDTO.BirthDate = student.BirthDate;
            foreach (var id in student.CourseId)
            {
                var course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
                if (course != null)
                {
                    studentDTO.Courses.Add(MakeCourseDTO(course));
                }
            }

            studentDTO.AveregeGrade = student.AverageGrade;

            return studentDTO;
        }

        public async Task<CourseDTO> CreateCourse(CoursePutPost model)
        {
            if (model.Title == null || model.Title == ""
                            || model.StartsAt == null || model.StartsAt == "")
            {
                throw new Exception("Invalid input!");
            }
            CultureInfo culture = CultureInfo.InvariantCulture;

            Course course = new Course();
            course.StartsAt = DateOnly.ParseExact(model.StartsAt, "yyyy-MM-dd", culture);
            course.Title = model.Title;

            _db.Courses.Add(course);
            await _db.SaveChangesAsync();

            return MakeCourseDTO(course);
        }

        public async Task<StudentDTO> CreateStudent(StudentPutPost model)
        {
            if (model.FirstName == null || model.LastName == ""
                                       || model.FirstName == null || model.LastName == ""
                                       || model.BirthDate == null || model.BirthDate == "" || model.AverageGrade < 0)
            {
                throw new Exception("Invalid input!");
            }

            foreach (var id in model.Courses)
            {
                var course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
                if (course == null)
                {
                    throw new Exception("Invalid input, course does not exist!");
                }

            }
                Student student = new Student();
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;

            CultureInfo culture = CultureInfo.InvariantCulture;
            student.BirthDate = DateOnly.ParseExact(model.BirthDate, "yyyy-MM-dd", culture);

            student.CourseId = model.Courses;
            student.AverageGrade = model.AverageGrade;

            _db.Students.Add(student);
            await _db.SaveChangesAsync();

            return await MakeStudentDTO(student);
        }


            public async Task<CourseDTO> DeleteCourse(int id)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
            {
                throw new Exception("Course does not exist");
            }
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return MakeCourseDTO(course);
        }

        public async Task<StudentDTO> DeleteStudent(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                throw new Exception("Course does not exist");
            }
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return await MakeStudentDTO(student);
        }

        public async Task<CourseDTO> GetCourseById(int id)
        {
            var course = _db.Courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                throw new Exception("Course does not exist");
            }
            return  MakeCourseDTO(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetCourses()
        {
            var courses = await _db.Courses.ToListAsync();
            List<CourseDTO> courseDTOs = new List<CourseDTO>();
            foreach (var course in courses)
            {
                courseDTOs.Add(MakeCourseDTO(course));
            }
            return courseDTOs;
        }
        public async Task<StudentDTO> GetStudentById(int id)
        {
            var student = _db.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new Exception("Student does not exist");
            }
            return await MakeStudentDTO(student);
        }

        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = await _db.Students.ToListAsync();
            List<StudentDTO> studentDTO = new List<StudentDTO>();
            foreach (var student in students)
            {
              studentDTO.Add(await MakeStudentDTO(student));
            }
            return studentDTO;
        }

        public async Task<CourseDTO> UpdateCourse(int id, CoursePutPost response)
        {
            if (response.StartsAt == null || response.StartsAt == "" ||
                           response.Title == null || response.Title == "")
            {
                throw new Exception("Invalid input!");
            }
            var course = _db.Courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                throw new Exception("Course does not exist");
            }
            CultureInfo culture = CultureInfo.InvariantCulture;


            course.StartsAt = DateOnly.ParseExact(response.StartsAt, "yyyy-MM-dd", culture);
            course.Title = response.Title;

            await _db.SaveChangesAsync();

            return MakeCourseDTO(course);
        }

        public async Task<StudentDTO> UpdateStudent(int id, StudentPutPost response)
        {
            if (response.FirstName == null || response.LastName == null || response.FirstName == "" || response.LastName == ""
                            || response.BirthDate == null || response.BirthDate == "" || response.AverageGrade < 0)
            {
                throw new Exception("Invalid input!");
            }
            var student = _db.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new Exception("Student does not exist");
            }
            student.FirstName = response.FirstName;
            student.LastName = response.LastName;

            CultureInfo culture = CultureInfo.InvariantCulture;
            student.BirthDate = DateOnly.ParseExact(response.BirthDate, "yyyy-MM-dd", culture);

            student.CourseId = response.Courses;
            student.AverageGrade = response.AverageGrade;

            await _db.SaveChangesAsync();

            return await MakeStudentDTO(student);
        }
    }
}
