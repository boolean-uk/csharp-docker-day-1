using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data
{
    public static class Seeder
    {
        public async static void SeedStudentDatabase(this WebApplication app)
        {
            using (var db = new DataContext()) {

                if (!db.Courses.Any())
                {
                    db.Courses.Add(new Course { Id = 1, Title = "Maths" });
                    await db.SaveChangesAsync();
                }
                if (!db.Students.Any()) {
                    db.Students.Add(new Student
                    {
                        Id = 1,
                        average_grade = 5.5,
                        CourseId = 1,                        
                        FirstName = "Ibz",
                        LastName = "Secka"
                    }); await db.SaveChangesAsync();
                }
            }
        }
    }
}
