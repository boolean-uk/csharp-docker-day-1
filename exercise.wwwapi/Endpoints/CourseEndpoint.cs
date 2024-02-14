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
            courses.MapGet("/{id}", GetCourse);
            courses.MapPost("/{id}", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();

            List<CourseDTO> courses = new List<CourseDTO>();
            foreach (var result in results) 
            {
                CourseDTO course = new CourseDTO()
                {
                    CourseTitle = result.CourseTitle,
                    CourseStartDate = result.CourseStartDate,
                    AverageGrade = result.AverageGrade
                };
                courses.Add(course);
            }
            var payload = new Payload<IEnumerable<CourseDTO>>() { data = courses };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourse(IRepository repository, int id)
        {
            var course = await repository.GetCourse(id);


            CourseDTO aCourse = new CourseDTO()
            {
                CourseTitle = course.CourseTitle,
                CourseStartDate = course.CourseStartDate,
                AverageGrade = course.AverageGrade
            };

            var payload = new Payload<CourseDTO>() { data = aCourse };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, Course course)
        {
            await repository.CreateCourse(course);

            CourseDTO aCourse = new CourseDTO()
            {
                CourseTitle = course.CourseTitle,
                CourseStartDate = course.CourseStartDate,
                AverageGrade = course.AverageGrade
            };

            var payload = new Payload<CourseDTO>() { data = aCourse };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, Course course)
        {
            await repository.UpdateCourse(id, course);


            CourseDTO aCourse = new CourseDTO()
            {
                CourseTitle = course.CourseTitle,
                CourseStartDate = course.CourseStartDate,
                AverageGrade = course.AverageGrade
            };

            var payload = new Payload<CourseDTO>() { data = aCourse };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var course = await repository.GetCourse(id);
            await repository.DeleteCourse(id);


            CourseDTO aCourse = new CourseDTO()
            {
                CourseTitle = course.CourseTitle,
                CourseStartDate = course.CourseStartDate,
                AverageGrade = course.AverageGrade
            };

            var payload = new Payload<CourseDTO>() { data = aCourse };
            return TypedResults.Ok(payload);
        }

    }
}
