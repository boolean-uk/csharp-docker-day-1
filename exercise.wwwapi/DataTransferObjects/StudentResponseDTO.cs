using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int AverageGrade { get; set; }
        public string CourseTitle { get; set; }
        public string CourseStartDate { get; set; }

        public StudentResponseDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DateOfBirth = student.DateOfBirth;
            AverageGrade = student.AverageGrade;
            CourseTitle = student.Course.Title;
            CourseStartDate = student.Course.StartDate;
        }
        public class StudentCreatedResponseDTO
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DateOfBirth { get; set; }
            public int AverageGrade { get; set; }
            public int CourseId { get; set; }

            public StudentCreatedResponseDTO(Student student)
            {
                Id = student.Id;
                FirstName = student.FirstName;
                LastName = student.LastName;
                DateOfBirth = student.DateOfBirth;
                AverageGrade = student.AverageGrade;
                CourseId = student.CourseId;
            }
        }
    }
}