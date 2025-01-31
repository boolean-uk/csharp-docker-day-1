using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
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
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, CourseDTO course)
        {
            var result = await repository.AddCourse(course);
            var payload = new Payload<Course>() { Data = result };
            return TypedResults.Created($"/courses/{result.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, CourseDTO courseDTO)
        {
            var courseToEdit = await repository.GetCourse(id);
            if (courseToEdit == null)
            {
                return TypedResults.NotFound();
            }

            courseToEdit.Name = courseDTO.Name;
            courseToEdit.Description = courseDTO.Description;

            var result = await repository.UpdateCourse(courseToEdit);
            var payload = new Payload<Course>() { Data = result };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var result = await repository.DeleteCourse(id);
            var payload = new Payload<Course>() { Data = result };
            return TypedResults.Ok(payload);
        }
    }
}
