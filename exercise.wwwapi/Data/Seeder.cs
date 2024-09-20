using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        private List<string> _firstnames = new List<string>()
        {
            "John",
            "James",
            "Caroline",
            "Audrey",
            "Liza",
            "Eliot"
        };
        private List<string> _lastnames = new List<string>()
        {
            "Hans",
            "Jing",
            "Wood",
            "Stone",
            "Carper",
            "McGoeth"
        };
        private List<string> _coursetitle = new List<string>()
        {
            "Mathematics",
            "Science",
            "Chemistry",
            "Physics",
            "Informatics"
        };

        private List<Course> _courses = new List<Course>();
        private List<Student> _students = new List<Student>();
        private List<CourseDetails> _courseDetails = new List<CourseDetails>();

        private DateTime GenerateRndTime()
        {
            DateTime start = DateTime.UtcNow.AddHours(-2000);
            Random rnd = new Random();
            DateTime rndTime = start.AddHours(rnd.Next(2000));

            return rndTime;
        }
        public Seeder()
        {
            Random random = new();

            for (int x = 0; x < 10; x++)
            {
                Student student = new()
                {
                    StudentId = x + 1,
                    FirstName = _firstnames[random.Next(_firstnames.Count)],
                    LastName = _lastnames[random.Next(_lastnames.Count)],
                    DateOfBirth = GenerateRndTime(),
                    StartDate = GenerateRndTime(),
                    AverageGrade = random.Next(6).ToString()
                };
                _students.Add(student);
            }
            for(int i = 0; i < _coursetitle.Count; i++)
            {
                Course course = new()
                {
                    CourseId = i + 1,
                    CourseTitle = _coursetitle[i],
                    StartDate = GenerateRndTime(),
                    AverageGrade = random.Next(6).ToString()
                };
                _courses.Add(course);
            }

            List<int> sValues = new() {1,2,3,4,5};
            List<int> cValues = new() {1,2,3,4,5};

            foreach (int x in sValues)
            {
                foreach (int y in cValues)
                {
                    CourseDetails details = new()
                    {
                        CourseId = x,
                        StudentId = y,
                    };

                    _courseDetails.Add(details);
                }
            }
        }

        public List<CourseDetails> Details { get { return _courseDetails; } }
        public List<Student> Students { get { return _students; } }
        public List<Course> Courses { get { return _courses; } }
    }
}
