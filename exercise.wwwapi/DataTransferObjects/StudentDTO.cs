using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int AvrageGrade { get; set; }
    
    
        public StudentDTO(Student student)
        {
            this.Id = student.Id;
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.DateOfBirth = student.DateOfBirth;
            this.AvrageGrade = student.AvrageGrade;
        }

        public static List<StudentDTO> FromStudents(IEnumerable<Student> students)
        {
            var results = new List<StudentDTO>();
            foreach (var student in students)
            {
                results.Add(new StudentDTO(student));
            }
            return results;
        }
    }


    public class StudentListResponseDTO
    {
        public List<StudentDTO> students { get; set; }    
        public StudentListResponseDTO(IEnumerable<Student> students)
        {
            this.students = new List<StudentDTO>();
            foreach (var student in students)
            {
                this.students.Add(new StudentDTO(student));
            }
        }
        
    }

    
}