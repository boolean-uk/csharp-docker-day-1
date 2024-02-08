namespace exercise.wwwapi.DataTransferObjects
{
    public record StudentUpdateData(
        string FirstName, 
        string LastName, 
        string DateOfBirth, 
        List<int> courseIDs );
    
    
}