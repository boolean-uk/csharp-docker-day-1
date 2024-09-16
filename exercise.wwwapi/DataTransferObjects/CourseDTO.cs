using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public decimal AvgGrade { get; set; }

        public CourseDTO(Course model)
        {
            Title = model.Title;
            StartDate = model.StartDate.ToString();
            AvgGrade = model.AvgGrade;
        }
    }
}
