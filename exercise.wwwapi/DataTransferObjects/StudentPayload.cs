namespace exercise.wwwapi.DataTransferObjects
{
    public record StudentPayload(
        string FirstName,
        string LastName,
        string DateOfBirth,
        int courseId,
        int averageGrade);
    
}