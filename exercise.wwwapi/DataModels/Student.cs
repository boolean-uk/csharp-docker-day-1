using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string CourseName { get; set; }
        public DateTime StartDateOfCourse { get; set; }
        public float AvarageGrade { get; set; }


    }
}
