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
            var courses = app.MapGroup("courses");
            courses.MapGet("/", GetCourses);
            courses.MapGet("/{id}", GetCourseById);
            courses.MapPost("/createcourse", CreateCourse);
            courses.MapPut("/updatecourse", UpdateCourse);
            courses.MapDelete("/deletecourse/{id}", DeleteCourse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            IEnumerable<Course> results = await repository.GetCourses();
            return TypedResults.Ok(CourseResponseDTO.FromRepository(results));
        }

        public static async Task<IResult> CreateCourse(IRepository repository, CoursePostPayload coursePostPayload)
        {
            var results = await repository.CreateCourse(coursePostPayload.title, coursePostPayload.startdate);
            if (results == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(results);
        }

        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var results = await repository.DeleteCourse(id);
            if (results == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(results);
        }

        public static async Task<IResult> GetCourseById(IRepository repository, int id)
        {
            Course results = await repository.GetCourseById(id);
            if (results == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(CourseResponseDTO.FromRepository(results));
        }


        public static async Task<IResult> UpdateCourse(IRepository repository, CourseUpdatePayload courseUpdatePayload)
        {
            var results = await repository.UpdateCourse(courseUpdatePayload.id, courseUpdatePayload.title, courseUpdatePayload.startdate);
            if (results == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(results);
        }
    }
}
