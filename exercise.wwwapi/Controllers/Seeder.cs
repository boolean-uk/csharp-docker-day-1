using exercise.wwwapi.Models.Models.Courses;
using exercise.wwwapi.Models.Models.Students;
using exercise.wwwapi.Models.Models.StudentCourses;

namespace exercise.wwwapi.Controllers
{
    public class Seeder
    {
        private static List<string> _firstnames = new List<string>()
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
            "Kate",
            "Ozzy",
            "Tony",
            "Geezer",
            "Bill",
            "Ronnie",
            "Keith",
            "Charlie",
            "Brian",
            "Roger",
            "Ginger",
            "Tom",
            "Chris",
            "Jimmy",
            "John",
            "Robert",
            "Paul",
            "Christopher",
            "Hank",
            "Veronica",
            "Jackie",
            "Janis",
            "Marilyn",
            "Alanis",
            "Britney"
        };
        private static List<string> _lastnames = new List<string>()
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
            "Middleton",
            "Osbourne",
            "Iommi",
            "Butler",
            "Ward",
            "Dio",
            "Moon",
            "Watts",
            "May",
            "Daltrey",
            "Baker",
            "Morello",
            "Cornell",
            "Page",
            "Bonham",
            "Plant",
            "McCartney",
            "Hitchens",
            "Von Helvete",
            "Maggio",
            "Onassis",
            "Joplin",
            "Monroe",
            "Morissette",
            "Spears"
        };

        private static List<string> _courseNames = new List<string>()
        {
            "C# programming 101",
            "C# programming 202",
            "C# programming 303",
            "Java for beginners",
            "Java for intermediates",
            "Java for experts",
            "Database design",
            "Database administration",
            "Database development",
            "Web development 101",
            "Web development 102",
            "Web development 103",
            "PHP for braindeads",
            "PHP for newts",
            "Git for gits",
            "UX design",
            "UI design",
            "Frontend development",
            "Backend development",
            "Fullstack development",
            "DevOps",
            "Cloud computing",
            "Machine learning",
            "Artificial intelligence",
            "Data science",
            "Big data and you",
            "Cybersecurity Introduciton",
            "Cybersecurity Intermediate",
            "Webscamming for scums",
            "Hacking for hacks",
            "Scrum for dummies",
            "Agile development",
            "Kanban for kids",
            "Lean for losers",
            "Internship 101",
            "Internship 102",
            "Project management",
            "Process management",
            "Test Driven Development",
            "System analysis and development",
            "Organization Theory",
            "Business Intelligence",
            "Service Design",
            "Data Science Applications",
            "Data Science II",
            "Blockchain",
            "Cryptocurrencies",
            "Internet of Things"
        };

        private List<Student> _students = new List<Student>();
        private List<Course> _courses = new List<Course>();
        private List<StudentCourse> _studentCourses = new List<StudentCourse>();

        public Seeder()
        {
            SeedStudents(20);
            SeedCourses(20);
            SeedStudentCourses(100);
        }

        public void SeedStudents(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var student = new Student()
                {
                    FirstName = _firstnames[i],
                    LastName = _lastnames[i],
                    DateOfBirth = DateGenerator()
                };
                _students.Add(student);
            }
        }

        public void SeedCourses(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var course = new Course()
                {
                    CourseTitle = _courseNames[i],
                    StartDate = DateGenerator()
                };
                _courses.Add(course);
            }
        }

        public void SeedStudentCourses(int count)
        {
            Random rnd = new Random();
            HashSet<(int studentId, int courseId)> registrations = new HashSet<(int studentId, int courseId)>(); // Use a HashSet to store unique registrations

            for (int i = 0; i < count; i++)
            {
                int studentId = _students[rnd.Next(0, _students.Count)].Id;
                int courseId = _courses[rnd.Next(0, _courses.Count)].Id;

                var studentCourse = (studentId, courseId);

                // Check if the registration already exists
                if (!registrations.Contains(studentCourse))
                {
                    registrations.Add(studentCourse); // Add the new registration to the HashSet
                    var studentCourseObj = new StudentCourse()
                    {
                        StudentId = studentId,
                        CourseId = courseId
                    };
                    _studentCourses.Add(studentCourseObj);
                }
                else
                {
                    // If the registration already exists, decrement the loop counter to try again for another registration
                    i--;
                }
            }
        }


        public DateOnly DateGenerator()
        {
            Random rnd = new Random();

            // Generate a random year between 1985 and 2006
            int year = rnd.Next(1985, 2007);

            // Generate a random month between 1 and 12
            int month = rnd.Next(1, 13);

            // Generate a random day between 1 and the maximum number of days in the selected month and year
            int maxDay = DateTime.DaysInMonth(year, month);
            int day = rnd.Next(1, maxDay + 1);

            // Create a DateTime object with the generated year, month, and day
            return new DateOnly(year, month, day);
        }

        public List<Student> Students { get => _students; }
        public List<Course> Courses { get => _courses; }
        public List<StudentCourse> StudentCourses { get => _studentCourses; }
    }
}
