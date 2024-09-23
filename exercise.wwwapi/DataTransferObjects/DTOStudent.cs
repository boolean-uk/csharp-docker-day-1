namespace exercise.wwwapi.DataTransferObjects
{
    public class DTOStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CourseForStudent Course { get; set; }
    }
}
