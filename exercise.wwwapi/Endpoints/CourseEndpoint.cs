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
            students.MapGet("/{courseId}", GetCourse);
            students.MapPut("/{courseId}", UpdateCourse);
            students.MapPost("/", CreateCourse);
            students.MapDelete("/{courseId}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourse(IRepository repository, int courseId)
        {
            if (courseId <= 0)
            {
                return TypedResults.BadRequest("id must be positive number above 0");
            }

            var result = await repository.GetCourse(courseId);
            if (result == null) 
            {
                return TypedResults.NotFound($"{courseId} is not a valid course id");
            }

            var payload = new Payload<Course>() { data = result };

            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int courseId, CourseUpdateData updateData)
        {
            if (courseId <= 0)
            {
                return TypedResults.BadRequest("id must be positive number above 0");
            }
            if (checkForEmptyOrNull(updateData.CourseTitle))
            {
                return TypedResults.BadRequest($"course title of the provided data was empty or null");
            }
            if (checkForEmptyOrNull(updateData.CourseStartDate))
            {
                return TypedResults.BadRequest($"course start date of the provided data was empty or null");
            }
            if (updateData.averageGrade < 0 || updateData.averageGrade >= 10)
            {
                return TypedResults.BadRequest($"Average Grade of the provided data has to be an integer between the values of 0 and 10");
            }

            var result = await repository.UpdateCourse(courseId,
                updateData.CourseTitle,
                updateData.CourseStartDate,
                updateData.averageGrade
                );

            if (result == null)
            {
                return TypedResults.NotFound("course id was not a valid Id");
            }

            var payload = new Payload<Course>() { data = result };

            return TypedResults.Ok(payload);


        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCourse(IRepository repository, CoursePayload coursePayload)
        {
            if (checkForEmptyOrNull(coursePayload.CourseTitle))
            {
                return TypedResults.BadRequest($"course title of the provided data was empty or null");
            }
            if (checkForEmptyOrNull(coursePayload.CourseStartDate))
            {
                return TypedResults.BadRequest($"course start date of the provided data was empty or null");
            }

            if (coursePayload.averageGrade < 0 || coursePayload.averageGrade >= 10)
            {
                return TypedResults.BadRequest($"Average Grade of the provided data has to be an integer between the values of 0 and 10");
            }

            var result = await repository.CreateCourse(
                coursePayload.CourseTitle,
                coursePayload.CourseStartDate,
                coursePayload.averageGrade
                );
            var payload = new Payload<Course>() { data = result };

            return TypedResults.Ok(payload);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int courseId)
        {
            if (courseId <= 0)
            {
                return TypedResults.BadRequest("id must be positive number above 0");
            }
            var payload = new Payload<Course> { data = await repository.GetCourse(courseId) };

            var result = await repository.DeleteCourse(courseId);

            if (result == null)
            {
                return TypedResults.NotFound($"{courseId} is not a valid course id");
            }

            if ((bool)result)
            {
                return TypedResults.Ok(payload);
            }
            else
            {
                return TypedResults.NotFound("could not delete course");
            }


        }

        private static bool checkForEmptyOrNull(string updateData)
        {
            if (updateData == null || updateData == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
