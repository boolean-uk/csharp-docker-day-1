using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        private List<Student> _students = new();
        private List<Course> _courses = new();
        
        public Seeder()
        {
            _students.Add(new Student() { Id = 1, FirstName = "Silje", LastName = "Jacobsen", DoB = new DateTime(2000, 07, 20).ToUniversalTime(), CourseId = 1 });
            _students.Add(new Student() { Id = 2, FirstName = "Daniel", LastName = "Røli", DoB = new DateTime(2000, 07, 20).ToUniversalTime(), CourseId = 2 });
            _students.Add(new Student() { Id = 3, FirstName = "Øyvind", LastName = "Onarheim", DoB = new DateTime(2000, 07, 20).ToUniversalTime(), CourseId = 2 });
            _students.Add(new Student() { Id = 4, FirstName = "Eyvind", LastName = "Malde", DoB = new DateTime(2000, 07, 20).ToUniversalTime(), CourseId = 1 });
            _students.Add(new Student() { Id = 5, FirstName = "Espen", LastName = "Luba", DoB = new DateTime(2000, 07, 20).ToUniversalTime(), CourseId = 1 });
            _courses.Add(new Course() { Id = 1, Title = "C#", AverageGrade = 5, CourseStart = new DateTime(2000, 07, 20).ToUniversalTime() });
            _courses.Add(new Course() { Id = 2, Title = "Java", AverageGrade = 2, CourseStart = new DateTime(2000, 07, 20).ToUniversalTime() });
        }


        public List<Student> Students { get { return _students; } }
        public List<Course> Courses { get { return _courses; } }


    }
}
