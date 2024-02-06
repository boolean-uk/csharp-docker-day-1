using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DTO
{
    public class DataDTO
    {
    }

    public class StudentDataDTO
    {
        public string status { get; set; }
        public Student data { get; set; }

        public StudentDataDTO(Student student, string status)
        {
            data = student;
            this.status = status;
        }
    }

    public class StudentListDataDTO
    {
        public string status { get; set; }
        public List<StudentDTO> data { get; set; }

        public StudentListDataDTO(List<StudentDTO> data, string status)
        {
            this.data = data;
            this.status = status;
        }
    }


    public class CourseDataDTO
    {
        public string status { get; set; }
        public Course data { get; set; }

        public CourseDataDTO(Course course, string status)
        {
            data = course;
            this.status = status;
        }
    }

    public class CourseListDataDTO
    {
        public string status { get; set; }
        public List<CourseDTO> data { get; set; }

        public CourseListDataDTO(List<CourseDTO> data, string status)
        {
            this.data = data;
            this.status = status;
        }
    }
}
