using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public string CourseTitle { get; set; }
        public DateOnly CourseStartDate { get; set; }
        public string AverageGrade { get; set; }

        public CourseDTO(Course course)
        {
            this.CourseTitle = course.CourseTitle;
            this.CourseStartDate = course.CourseStartDate;
            this.AverageGrade = course.AverageGrade;
        }
    }
}
