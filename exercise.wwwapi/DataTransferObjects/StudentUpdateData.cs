namespace exercise.wwwapi.DataTransferObjects
{
    public record StudentUpdateData(
        string FirstName, 
        string LastName, 
        string DateOfBirth, 
        int CourseId,
        int averageGrade );
    
    
}