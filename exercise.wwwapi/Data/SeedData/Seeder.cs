using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data.SeedData
{
    public class Seeder
    {
        private List<Course> _courses { get; set; } = new List<Course>();
        private List<Student> _students { get; set; } = new List<Student>();

        public Seeder()
        {
            Course course = new Course()
            {
                Id = 1,
                CourseTitle = "Fullstack C#",
                CourseStartDate = DateTime.SpecifyKind(new DateTime(2024, 01, 07), DateTimeKind.Utc),
            };

            Course course2 = new Course() 
            {
                Id = 2,
                CourseTitle = "Fullstack Java",
                CourseStartDate = DateTime.SpecifyKind(new DateTime(2024, 01, 07), DateTimeKind.Utc),
            };

            Student student = new Student()
            {
                Id = 1,
                FirstName = "Stian",
                LastName = "Gaustad",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 08, 20), DateTimeKind.Utc),
                CourseID = 1,
                AverageGrade = 3,
            };

            Student student2 = new Student()
            {
                Id = 2,
                FirstName = "Tølløv",
                LastName = "Aresvik",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 04, 15), DateTimeKind.Utc),
                CourseID = 1,
                AverageGrade = 3,
            };

            Student student3 = new Student()
            {
                Id = 3,
                FirstName = "Ole Markus",
                LastName = "Roland",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 04, 15), DateTimeKind.Utc),
                CourseID = 1,
                AverageGrade = 3,
            };

            Student student4 = new Student()
            {
                Id = 4,
                FirstName = "Alexander",
                LastName = "Gatland",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 07, 15), DateTimeKind.Utc),
                CourseID = 2,
                AverageGrade = 3,
            };

            Student student5 = new Student()
            {
                Id = 5,
                FirstName = "Nora",
                LastName = "Hansen",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 01, 15), DateTimeKind.Utc),
                CourseID = 2,
                AverageGrade = 3,
            };

            Student student6 = new Student()
            {
                Id = 6,
                FirstName = "Marit",
                LastName = "Moe",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 09, 15), DateTimeKind.Utc),
                CourseID = 2,
                AverageGrade = 3,
            };

            _courses.Add(course);
            _courses.Add(course2);
            _students.Add(student);
            _students.Add(student2);
            _students.Add(student3);
            _students.Add(student4);
            _students.Add(student5);
            _students.Add(student6);

        }

        public List<Course> Courses { get { return _courses; } }
        public List<Student> Students { get {  return _students; } }
    }
}
