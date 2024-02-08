namespace exercise.wwwapi.DataModels
{
    public record StudentUpdatePayload(int id, string firstname, string lastname, DateTime dateofbirth, int avgGrade);
}