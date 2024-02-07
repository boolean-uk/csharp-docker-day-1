using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/", GetCourses);
        }

        //get all courses
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            List<CourseResponseDTO> resultList = new List<CourseResponseDTO>();
            foreach (var course in results)
            {
                CourseResponseDTO courseToReturn = new CourseResponseDTO(course);
                resultList.Add(courseToReturn);
            }
            return TypedResults.Ok(resultList);
        }
    }
}
