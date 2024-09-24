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
            students.MapGet("/{id}", GetCourse);
            students.MapPost("/", CreateCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }
        

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<CourseDTO>>() { Data = results };
            return TypedResults.Ok(payload);
        }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetCourse(IRepository repository, int id)
    {
        var results = await repository.GetCourseById(id);
        var payload = new Payload<CourseDTO>() { Data = results };
        return TypedResults.Ok(payload);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    public static async Task<IResult> CreateCourse(IRepository repository, CoursePutPost model)
    {


            try
            {
                var results = await repository.CreateCourse(model);
                var payload = new Payload<CourseDTO> { Data = results };

                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
    }


    [ProducesResponseType(StatusCodes.Status201Created)]
    public static async Task<IResult> UpdateCourse(IRepository repository, int id, CoursePutPost model)
    {

            try
            {
                var results = await repository.UpdateCourse(id, model);
              
                var payload = new Payload<CourseDTO>() { Data = results  };

                return TypedResults.Ok(payload.Data);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
       
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> DeleteCourse(IRepository repository, int id)
    {
            try
            {
                var results = await repository.DeleteCourse(id);
              
                var payload = new Payload<CourseDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
    }
}
}
