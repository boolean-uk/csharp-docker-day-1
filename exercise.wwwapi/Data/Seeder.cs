using exercise.wwwapi.DataModels;
using System.Globalization;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        private List<string> _firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate"
        };
        private List<string> _lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton"

        };
        private List<string> _domain = new List<string>()
        {
            "bbc.co.uk",
            "google.com",
            "theworld.ca",
            "something.com",
            "tesla.com",
            "nasa.org.us",
            "gov.us",
            "gov.gr",
            "gov.nl",
            "gov.ru"
        };
        private List<string> _firstword = new List<string>()
        {
            "The",
            "Two",
            "Several",
            "Fifteen",
            "A bunch of",
            "An army of",
            "A herd of"


        };
        private List<string> _secondword = new List<string>()
        {
            "Orange",
            "Purple",
            "Large",
            "Microscopic",
            "Green",
            "Transparent",
            "Rose Smelling",
            "Bitter"
        };
        private List<string> _thirdword = new List<string>()
        {
            "Buildings",
            "Cars",
            "Planets",
            "Houses",
            "Flowers",
            "Leopards"
        };
        List<string> _dates = new List<string>
        {
            "2024-09-12 13:45:00 UTC",
            "2024-09-12 14:00:00 UTC",
            "2024-09-12 14:15:00 UTC",
            "2024-09-12 14:30:00 UTC",
            "2024-09-12 14:45:00 UTC",
            "2024-09-12 15:00:00 UTC",
            "2024-09-12 15:15:00 UTC",
            "2024-09-12 15:30:00 UTC",
            "2024-09-12 15:45:00 UTC",
            "2024-09-12 16:00:00 UTC"
        };
        List<char> _grades = new List<char>()
        {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F'
        };

        private List<Student> _students = new List<Student>();
        private List<Course> _courses = new List<Course>();


        public Seeder()
        {

            Random studentRandom = new Random();
            Random courseRandom = new Random();




            for (int x = 1; x < 250; x++)
            {
                Student student = new Student();
                student.Id = x;
                student.FirstName = _firstnames[studentRandom.Next(_firstnames.Count)];
                student.LastName = _lastnames[studentRandom.Next(_lastnames.Count)];
                _students.Add(student);
            }


            for (int x = 1; x < 25; x++)
            {
                Course course = new Course();
                course.Id = x;
                course.CourseTitle = _firstword[courseRandom.Next(_firstword.Count)];
                course.AverageGrade = _grades[courseRandom.Next(_grades.Count)];
                string date = _dates[courseRandom.Next(_dates.Count)];
                string format = "yyyy-MM-dd HH:mm:ss 'UTC'";
                course.CourseStartDate = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
                _courses.Add(course);
            }



        }
        public List<Student> Students { get { return _students; } }
        public List<Course> Courses { get { return _courses; } }
    }
}
