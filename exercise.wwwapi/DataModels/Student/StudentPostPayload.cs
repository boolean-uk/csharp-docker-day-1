namespace exercise.wwwapi.DataModels
{
    public record StudentPostPayload(string firstname, string lastname, DateTime dateofbirth, int avgGrade);
}