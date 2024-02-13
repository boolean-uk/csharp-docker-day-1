using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using exercise.wwwapi.DataTransferObjects.Students;

namespace exercise.wwwapi.DataTransferObjects.Courses
{
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
