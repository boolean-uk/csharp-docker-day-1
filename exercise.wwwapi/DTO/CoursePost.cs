using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DTO
{
    public class CoursePost
    {                     
        public string Description { get; set; }        
    }
}
