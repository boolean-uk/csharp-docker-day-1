using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data
{
    public static class Seeder
    {

        public static async void SeedApi(this WebApplication app)
        {
            DataContext db = new DataContext();

            if (!db.Courses.Any())
            {
                List<Course> courses =
                    [
                        new () {Title = "Algorithms and Datastructures 2", StartDate = DateTime.UtcNow},
                        new () {Title = "Macro Economics", StartDate= DateTime.UtcNow},
                        new () {Title = "Volcanoes For the Curious", StartDate = DateTime.UtcNow}
                    ];
                db.Courses.AddRange(courses);
                await db.SaveChangesAsync();
            }

            if (!db.Students.Any())
            {
                List<Student> students = 
                    [
                        new () {FirstName = "Agron", LastName = "Metaj" , CourseId = 1, AverageGrade = 4.35m, DateOfBirth = DateTime.Parse("1998-12-31").ToUniversalTime()},
                        new () {FirstName = "Dave", LastName = "Ames", CourseId = 2, AverageGrade = 3.99m, DateOfBirth = DateTime.Parse("1958-09-19").ToUniversalTime()},
                        new () {FirstName = "Nigel", LastName = "Sibbert", CourseId = 3, AverageGrade = 4.99m, DateOfBirth = DateTime.Parse("1965-06-06").ToUniversalTime()}
                    ];
                db.Students.AddRange(students);
                await db.SaveChangesAsync();
            }
        }
    }
}
