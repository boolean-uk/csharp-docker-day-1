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

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public static async Task<IResult> CreateCourse(IRepository<Course> repository, PostCourse courseData)
    {
        var newCourse = new Course()
        {
            Title = courseData.Title,
        };
        var existingCourses = await repository.GetAll();
        if (existingCourses.Any(x => x.Title == courseData.Title))
        {
            return TypedResults.BadRequest($"A course with the title {courseData.Title} already exist!");
        }
        var result = await repository.Create(newCourse);
        var payload = new Payload<CourseDTO>() { data = CourseDTO.ToDTO(result) };
        return TypedResults.Created($"/{result.Id}", payload);
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

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetCourse(IRepository<Course> repository, int id)
    {
        var result = await repository.GetById(id);
        if (result == null)
        {
            return TypedResults.NotFound($"There is no course with the id: {id}!");
        }
        var payload = new Payload<CourseDTO>() { data = CourseDTO.ToDTO(result) };
        return TypedResults.Ok(payload);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, PostCourse courseData)
    {
        var toUpdate = await repository.GetById(id);
        if (toUpdate == null)
        {
            return TypedResults.NotFound($"There is no course with the id: {id}!");
        }    
        var existingCourses = await repository.GetAll();
        if (existingCourses.Any(x => x.Title == courseData.Title))
        {
            return TypedResults.BadRequest($"A course with the title {courseData.Title} already exist!");
        }
        var result = await repository.Update(toUpdate);
        var payload = new Payload<CourseDTO>() { data = CourseDTO.ToDTO(result) };
        return TypedResults.Created($"/{result.Id}", payload);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
    {
        var result = await repository.Delete(id);
        if (result == null)
        {
            return TypedResults.NotFound($"There is no course with the id: {id}!");
        }
        var payload = new Payload<CourseDTO>() { data = CourseDTO.ToDTO(result) };
        return TypedResults.Ok(payload);
    }
}
