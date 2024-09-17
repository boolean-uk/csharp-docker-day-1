namespace exercise.wwwapi.DTOs
{
    public class GetCourseDTO
    {
          public int id { get; set; }

        public string courseName { get; set; }

        public List<GetStudentDTO> students { get; set; }

        }
    }
