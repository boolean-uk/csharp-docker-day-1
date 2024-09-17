using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModels;
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
            courses.MapPost("/", AddCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }
    

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var courses = await repository.GetAll();
            var courseResponse = courses.Select(s => new CourseDTO(s));
            var response = new Response<IEnumerable<CourseDTO>>() { Data = courseResponse };
            return TypedResults.Ok(response);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseById(IRepository<Course> repository, int id)
        {
            var course = await repository.GetById(id);
            var response = new Response<CourseDTO>() { Data = new CourseDTO(course) };
            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddCourse(IRepository<Course> repository, CoursePayload model)
        {
            var courses = await repository.GetAll();

            if (courses.Any(c => c.Title == model.Title))
            {
                return TypedResults.BadRequest($"{model.Title} already exists");
            }

            var addCourse = new Course() { Title = model.Title, CourseStart = model.CourseStart, AverageGrade = model.AverageGrade};
            addCourse = await repository.Add(addCourse);
            var response = new Response<CourseDTO>() { Data = new CourseDTO(addCourse) };
            return TypedResults.Ok(response);
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CoursePayload model)
        {
            var updateCourse = await repository.GetById(id);
            updateCourse.Title = model.Title;
            updateCourse.CourseStart = model.CourseStart;
            updateCourse.AverageGrade = model.AverageGrade;

            var result = await repository.Update(updateCourse);

            var response = new Response<CourseDTO>() { Data = new CourseDTO(result) };

            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            Response<IEnumerable<CourseDTO>> response = new();
            List<CourseDTO> CourseDTO = new();
            var deletedCourse = await repository.Delete(id);
            CourseDTO.Add(new CourseDTO(deletedCourse));
            response.Data = CourseDTO;
            return TypedResults.Ok(response);
        }

    }
}
