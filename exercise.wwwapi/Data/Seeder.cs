using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        public List<Course> Courses = new List<Course>()
        {
            new Course(){Id = 1, Title = "Math", StartDate = DateTime.UtcNow.AddDays(20)},
            new Course(){Id = 2, Title = "English", StartDate = DateTime.UtcNow.AddDays(30)},
        };

        public List<Student> Students = new List<Student>()
        {
            new Student(){Id = 1, FirstName = "Cillian", LastName = "Murphy", DateOfBirth= DateTime.UtcNow.AddYears(-30), AverageGrade = "B"},
            new Student(){Id = 2, FirstName = "Christian", LastName = "Bale", DateOfBirth= DateTime.UtcNow.AddYears(-28), AverageGrade = "A"},
            new Student(){Id = 3, FirstName = "Tom", LastName = "Hardy", DateOfBirth= DateTime.UtcNow.AddDays(-20), AverageGrade = "C"},
        };
    }
}
