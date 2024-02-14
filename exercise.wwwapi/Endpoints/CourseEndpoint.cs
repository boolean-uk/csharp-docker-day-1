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
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            Payload<List<GetCourseDto>> output = new();
            output.data = new();
            foreach(Course course in await repository.Get())
            {
                output.data.Add(new GetCourseDto(course));
            }
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, PostCourse newCourse)
        {
            Payload<CourseDto> output = new();

            var courses = await repository.Get();
            Course course = new Course(newCourse);
            course.Id = courses.Last().Id + 1;

            output.data = new CourseDto(await repository.Create(course));
            return TypedResults.Created($"/{output.data.Id}", output);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, PostCourse updateCourse)
        {
            Payload<GetCourseDto> output = new();

            Course course = await repository.GetById(id);
            if (course == null)
            {
                output.status = "not found";
                return TypedResults.NotFound(output);
            }

            course.Title = updateCourse.Title != null ? updateCourse.Title : output.data.Title;
            course.AverageGrade = updateCourse.AverageGrade != null ? updateCourse.AverageGrade : output.data.AverageGrade;
            course.StartDate = updateCourse.StartDate != null ? updateCourse.StartDate : output.data.StartDate;

            output.data = new GetCourseDto(await repository.Update(course));

            return TypedResults.Created($"/{output.data.Id}", output);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            Payload<CourseDto> output = new();
            Course course = await repository.GetById(id);
            if (course == null)
            {
                output.status = "failed";
                return TypedResults.NotFound(output);
            }
            output.data = new CourseDto(await repository.Delete(id));
            if (output.data == null)
            {
                output.status = "failed";
                return TypedResults.NotFound(output);
            }
            return TypedResults.Ok(output);
        }
    }
}
