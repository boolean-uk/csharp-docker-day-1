using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using exercise.wwwapi.Interfaces;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO : ICourse
    {
        public int Id { get; set; }

        public string CourseTitle { get; set; }

        public char AverageGrade { get; set; }

        public DateTime StartDate { get; set; }
    }
}

