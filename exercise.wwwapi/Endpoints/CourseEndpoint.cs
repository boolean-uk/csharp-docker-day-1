using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataViews;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        private static string _path = AppContext.BaseDirectory;
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/", GetCourses);
            students.MapPost("/", CreateCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var resultList = await repository.GetAll([]);
            var resultDTOs = new List<CourseDTO>();
            foreach (var result in resultList)
            {
                resultDTOs.Add(new CourseDTO(result));
            }
            var payload = new Payload<IEnumerable<CourseDTO>>() { Data = resultDTOs };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, CourseView view)
        {
            var model = new Course()
            {
                Title = view.Title,
                StartDate = DateTime.Parse(view.StartDate).ToUniversalTime(),
                AvgGrade = view.AvgGrade
            };
            var result = await repository.Create([], model);
            var resultDTO = new CourseDTO(result);

            var payload = new Payload<CourseDTO>() { Data = resultDTO };
            return TypedResults.Created(_path, payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CourseView view)
        {
            var model = new Course()
            {
                Id = id,
                Title = view.Title,
                StartDate = DateTime.Parse(view.StartDate).ToUniversalTime(),
                AvgGrade = view.AvgGrade
            };
            var result = await repository.Update([], model);
            var resultDTO = new CourseDTO(result);

            var payload = new Payload<CourseDTO>() { Data = resultDTO };
            return TypedResults.Created(_path, payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var result = await repository.Delete([], new Course() { Id = id });
            var resultDTO = new CourseDTO(result);
            var payload = new Payload<CourseDTO>() { Data = resultDTO };
            return TypedResults.Ok(payload);
        }
    }
}
