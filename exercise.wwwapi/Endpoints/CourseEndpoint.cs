using exercise.wwwapi.DataModels.Course;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints;

/// <summary>
/// Extension endpoint
/// </summary>
public static class CourseEndpoint
{
    public static void CourseEndpointConfiguration(this WebApplication app)
    {
        var courses = app.MapGroup("courses");
        courses.MapPost("/", CreateCourse);
        courses.MapGet("/", GetCourses);
        courses.MapGet("/{id}", GetCourse);
        courses.MapPut("/{id}", UpdateCourse);
        courses.MapDelete("/{id}", DeleteCourse);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetCourses(IRepository<Course> repository)
    {
        var results = await repository.GetAll();
        var returnList = new List<CourseDTO>();
        foreach (var result in results)
        {
            returnList.Add(CourseDTO.ToDTO(result));
        }
        var payload = new Payload<IEnumerable<CourseDTO>>() { data = returnList };
        return TypedResults.Ok(payload);
    }
}
