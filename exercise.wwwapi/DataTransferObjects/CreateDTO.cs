namespace exercise.wwwapi.DataTransferObjects
{
    public record CreateStudentDTO(string FirstName, string LastName, DateTime DateOfBirth, DateTime StartDate, string AverageGrade)
    {
        
    }
    public record CreateCourseDTO(string CourseTitle, DateTime StartDate, string AverageGrade)
    {

    }

}
