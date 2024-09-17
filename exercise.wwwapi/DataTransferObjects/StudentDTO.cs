using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class ResponseStudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public ResponseCourseDTOStudentLess Course { get; set; }

        public ResponseStudentDTO(Student model)
        {
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            DateOfBirth = model.DateOfBirth.ToString();
            Course = new ResponseCourseDTOStudentLess(model.Course);
        }
    }

    public class ResponseStudentDTOCourseLess
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }

        public ResponseStudentDTOCourseLess(Student model)
        {
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            DateOfBirth = model.DateOfBirth.ToString();
        }
    }

    public class PostStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int CourseId { get; set; }
    }

    public class PutStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int CourseId { get; set; }
    }
}
