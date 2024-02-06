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
            return await _db.Courses.Include(x => x.Students).ToListAsync();
        }


        public async Task<Course?> GetCourse(int CourseId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Courses.Include(a => a.Students).FirstOrDefaultAsync(s => s.Id == CourseId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _db.Courses.FirstOrDefaultAsync(s => s.Id == CourseId);
                default:
                    return null;
            }
        }

        public async Task<Course?> DeleteCourse(int CourseId, PreloadPolicy preloadPolicy = PreloadPolicy.PreloadRelations)
        {
            var mv = await _db.Courses.Include(a => a.Students).FirstOrDefaultAsync(s => s.Id == CourseId);


            if (mv == null) {
                return null;
            }

            List<Student> scr = _db.Students.Where(x => x.CourseId == mv.Id).ToList();

            foreach (Student sc in scr)
            {
                mv.Students.Remove(sc);
            }

            _db.Courses.Remove(mv);

            return mv;
                
        }

        public async Task<Course?> CreateCourse(string title, DateTime startDate)
        {
            if (title == "" || startDate == null) return null;

            var Course = new Course { 
                Title = title, 
                StartDate = startDate };

            await _db.Courses.AddAsync(Course);
            
            return Course;
        }

        public async Task<Course?> UpdateCourse(int courseId, string? title, DateTime? startDate, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {

            var mv = await _db.Courses.Include(x => x.Students).FirstOrDefaultAsync(s => s.Id == courseId);

            if (mv == null)
            {
                return null;
            }

            if (title !=  null) { mv.Title = title; }

            if (startDate != null) {  mv.StartDate = (DateTime)startDate; }

            return mv;

        }






        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }



        public async Task<Student?> GetStudent(int studentId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _db.Students.FirstOrDefaultAsync(s => s.Id == studentId);
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

        public async Task<Student?> CreateStudent(string firstName, string lastName, DateTime dob, int courseId, float averageGrade)
        {
            if (firstName == "" || lastName == "" ||  courseId <= 0 || averageGrade <= 0.0F) return null;


            var cours = _db.Courses.FirstOrDefault(x => x.Id == courseId);

            if (cours == null) {
                return null;
            }


            var Student = new Student { 
                FirstName = firstName, 
                LastName = lastName,
                DOB = dob, 
                CourseId = courseId,
                Course = cours,
                AverageGrade = averageGrade };

            await _db.Students.AddAsync(Student);
            
            return Student;
        }

        public async Task<Student?> UpdateStudent(int StudentId, string? firstName, string? lastName, DateTime? dob, int? courseId, float? averageGrad, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {

            var mv = await _db.Students.FirstOrDefaultAsync(s => s.Id == StudentId);

            if (mv == null)
            {
                return null;
            }

            if (firstName !=  null) { mv.FirstName = firstName; }

            if (lastName !=  null) { mv.LastName = lastName; }

            if (dob != null) {  mv.DOB = (DateTime)dob; }
            
            if (courseId > 0 ) 
            {  
                mv.CourseId = (int)courseId; 

                var crs = _db.Courses.FirstOrDefault(x => x.Id == courseId);
                mv.Course = crs;
                
            }

            if (averageGrad >= 0.0F) { mv.AverageGrade = (float)averageGrad; }
            

            return mv;

        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }


    }
}
