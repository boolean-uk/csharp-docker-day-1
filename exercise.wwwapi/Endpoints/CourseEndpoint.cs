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

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            List<CourseResponseDTO> listResults = new List<CourseResponseDTO>();
            foreach (var course in results)
            {
                CourseResponseDTO returnCourse = new CourseResponseDTO(course);
                listResults.Add(returnCourse);
            }
            return TypedResults.Ok(listResults);
        }
    }
}
