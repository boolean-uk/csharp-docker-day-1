namespace exercise.wwwapi.DataModels
{
    public class StudentDTO
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string CourseTitle { get; set; }

        public DateTime CourseStartDate { get; set; }

        public float AverageGrade { get; set; }

        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Birthdate = student.Birthdate;
            CourseTitle = student.CourseTitle;
            CourseStartDate = student.CourseStartDate;
            AverageGrade = student.AverageGrade;
        }
    }
}
