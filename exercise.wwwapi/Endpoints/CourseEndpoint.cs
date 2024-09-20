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
            students.MapPost("/", CreateCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            try
            {
                var results = await repository.GetCourses();
                var payload = new Payload<IEnumerable<Course>>() { Data = results };
                return TypedResults.Ok(payload);

            }
            catch (InvalidOperationException ex)
            {
                return TypedResults.NoContent();
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, CreateCourseDTO courseDTO)
        {
            try
            {
                Course course = new()
                {
                    CourseTitle = courseDTO.CourseTitle,
                    StartDate = courseDTO.StartDate,
                    AverageGrade = courseDTO.AverageGrade
                };
                var results = await repository.CreateCourse(course);
                return TypedResults.Created();

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository repository, CreateCourseDTO createCourseDTO, int id)
        {
            try
            {
                var result = await repository.UpdateCourse(createCourseDTO, id);
                return TypedResults.Created("Created", result);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            try
            {
                var result = await repository.DeleteCourse(id);
                return TypedResults.Ok(result);
            }
            catch
            {
                return TypedResults.BadRequest();
            }
        }

    }
}
