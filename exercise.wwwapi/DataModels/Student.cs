using System.Xml;

namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB {  get; set; }
        public double AvgGrade { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}