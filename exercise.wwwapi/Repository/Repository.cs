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
            return await _db.Courses.Include(x => x.CourseStudents).ThenInclude(x => x.Student).ToListAsync();
        }


        public async Task<Course?> GetCourse(int CourseId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Courses.Include(x => x.CourseStudents).ThenInclude(x => x.Student).FirstOrDefaultAsync(s => s.Id == CourseId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.Courses.FirstOrDefaultAsync(s => s.Id == CourseId);
                default:
                    return null;
            }
        }

        public async Task<Course?> DeleteCourse(int CourseId, PreloadPolicy preloadPolicy = PreloadPolicy.PreloadRelations)
        {
            var mv = await _db.Courses.Include(x => x.CourseStudents).ThenInclude(x => x.Student).FirstOrDefaultAsync(s => s.Id == CourseId);


            if (mv == null) {
                return null;
            }


            mv.CourseStudents.Clear();
            
            _db.Courses.Remove(mv);

            return mv;
                
        }

        public async Task<Course?> CreateCourse(string title, string teacher, DateTime startDate)
        {
            if (title == "" || teacher == "" || startDate == null) return null;

            var Course = new Course { 
                Title = title, 
                Teacher = teacher,
                StartDate = startDate };

            await _db.Courses.AddAsync(Course);
            
            return Course;
        }

        public async Task<Course?> UpdateCourse(int courseId, string? title, string? teacher, DateTime? startDate, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {

            var mv = await _db.Courses.Include(x => x.CourseStudents).ThenInclude(x => x.Student).FirstOrDefaultAsync(s => s.Id == courseId);

            if (mv == null)
            {
                return null;
            }

            if (title !=  null) { mv.Title = title; }

            if (teacher !=  null) { mv.Teacher = teacher; }

            if (startDate != null) {  mv.StartDate = (DateTime)startDate; }

            return mv;

        }






        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(x => x.CourseStudent).ThenInclude(x => x.Course).ToListAsync();
        }



        public async Task<Student?> GetStudent(int studentId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Students.Include(x => x.CourseStudent).ThenInclude(x => x.Course).FirstOrDefaultAsync(s => s.Id == studentId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.Students.FirstOrDefaultAsync(s => s.Id == studentId);
                default:
                    return null;
            }
        }


        public async Task<Student?> DeleteStudent(int StudentId, PreloadPolicy preloadPolicy = PreloadPolicy.PreloadRelations)
        {
            var mv = await _db.Students.FirstOrDefaultAsync(s => s.Id == StudentId);

            if (mv == null) {
                return null;
            }

            _db.Students.Remove(mv);

            return mv;
                
        }

        public async Task<Student?> CreateStudent(string firstName, string lastName, DateTime dob, float averageGrade)
        {
            if (firstName == "" || lastName == "" || averageGrade <= 0.0F) return null;

            var Student = new Student { 
                FirstName = firstName, 
                LastName = lastName,
                DOB = dob, 
                AverageGrade = averageGrade };

            await _db.Students.AddAsync(Student);
            return Student;
        }

        public async Task<Student?> UpdateStudent(int StudentId, string? firstName, string? lastName, DateTime? dob, float? averageGrad, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {

            var mv = await _db.Students.FirstOrDefaultAsync(s => s.Id == StudentId);

            if (mv == null)
            {
                return null;
            }

            if (firstName !=  null) { mv.FirstName = firstName; }

            if (lastName !=  null) { mv.LastName = lastName; }

            if (dob != null) {  mv.DOB = (DateTime)dob; }

            if (averageGrad >= 0.0F) { mv.AverageGrade = (float)averageGrad; }
            

            return mv;

        }


        public async Task<IEnumerable<CourseStudent>> GetCourseStudents()
        {
            return await _db.CourseStudents.Include(x => x.Course).Include(x => x.Student).ToListAsync();
        }

        public async Task<CourseStudent?> GetCourseStudent(int courseId, int studentId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.CourseStudents.Include(x => x.Course).Include(x => x.Student).Where(d => d.CourseId == courseId).FirstOrDefaultAsync(s => s.StudentId == studentId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.CourseStudents.Where(d => d.CourseId == courseId).FirstOrDefaultAsync(s => s.StudentId == studentId);
                default:
                    return null;
            }
        }

        public async Task<CourseStudent?> CreateCourseStudent(int courseId, int studentId)
        {
            if (courseId.GetType() != typeof(int)) return null;
            if (studentId.GetType() != typeof(int)) return null;

            var c = _db.Courses.FirstOrDefault(x => x.Id == courseId);
            var s = _db.Students.FirstOrDefault(x => x.Id == studentId);

            if (c == null || s == null)
            {
                return null;
            }

            var cs = new CourseStudent
            {
                CourseId = courseId,
                Course = c,
                StudentId = studentId,
                Student = s
            };
            await _db.CourseStudents.AddAsync(cs);
            return cs;
        }

        public async Task<CourseStudent?> DeleteCourseStudent(int CourseId, int StudentId, PreloadPolicy preloadPolicy = PreloadPolicy.PreloadRelations)
        {
            var mv = await _db.CourseStudents.Include(x => x.Course).Include(x => x.Student).Where(x => x.CourseId == CourseId).FirstOrDefaultAsync(s => s.StudentId == StudentId);

            if (mv == null)
            {
                return null;
            }

            _db.CourseStudents.Remove(mv);

            return mv;

        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }


    }
}
