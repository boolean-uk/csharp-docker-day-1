using exercise.wwwapi.DataModels;
using System.Security.Cryptography.X509Certificates;

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
        private List<string> _titles = new List<string>()
        {
            "Java",
            "C#",
            "JavaScript",
            ".NET"
        };

        private List<string> _dateOfBirths = new List<string>()
        {
            "1990, 5, 15",
            "1985, 10, 3",
            "1978, 12, 25",
            "2001, 8, 9",
            "1996, 4, 30",
            "1982, 7, 18",
            "1975, 9, 22",
            "2005, 11, 7",
            "1993, 2, 14",
            "1970, 6, 28"
        };  

        private List<string> _courseStartDate = new List<string>()
        {
            "2024, 5, 15",
            "2024, 10, 3",
            "2024, 12, 25",
            "2024, 8, 9",
            "2024, 4, 30",
            "2024, 7, 18",
            "2024, 9, 22",
            "2024, 11, 7",
            "2024, 2, 14",
            "2024, 6, 28"
        };

        private List<double> _averageGrade = new List<double>()
        {
            1, 2, 3, 4, 5, 6
        };

        public List<int> _courseId = new List<int>()
        {
            1, 2, 3, 4
        };

        private List<Student> _students = new List<Student>();
        private List<Course> _courses = new List<Course>();

        public Seeder()
        {
            Random rand = new Random();

            for (int i = 1; i <= 10; i++)
            {
                Student student = new Student();

                student.Id = i;
                student.FirstName = _firstnames[rand.Next(_firstnames.Count)];
                student.LastName = _lastnames[rand.Next(_lastnames.Count)];
                student.DateOfBirth = _dateOfBirths[rand.Next(_dateOfBirths.Count)];
                student.CourseId = _courseId[rand.Next(_courseId.Count)];
                _students.Add(student);
            }

            for(int j = 1; j <= 10; j++)
            {
                Course aCourse = new Course();
                aCourse.Id = j;
                aCourse.CourseStartDate = _courseStartDate[rand.Next(_courseStartDate.Count)];
                aCourse.CourseTitle = _titles[rand.Next(_titles.Count)];
                aCourse.AverageGrade = _averageGrade[rand.Next(_averageGrade.Count)];
                _courses.Add(aCourse);
            }

        }

        public List<Student> Students { get { return _students; } }
        public List<Course> Courses { get { return _courses; } }
    }
}
