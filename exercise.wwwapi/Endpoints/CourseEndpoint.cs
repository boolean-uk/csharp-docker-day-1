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
        private static string _path = AppContext.BaseDirectory;
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var courses = app.MapGroup("courses");
            courses.MapGet("/", GetCourses);
            courses.MapGet("/{id}", GetCourse);
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var resultList = await repository.GetAll(inclusions: ["Students"]);
            var resultDTOs = new List<ResponseCourseDTO>();
            foreach (var result in resultList)
            {
                resultDTOs.Add(new ResponseCourseDTO(result));
            }
            var payload = new Payload<IEnumerable<ResponseCourseDTO>>() { Status = "Success", Data = resultDTOs };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourse(IRepository<Course> repository, int id)
        {
            var result = await repository.Get(inclusions: ["Students"], predicate: x => x.Id == id);
            var resultDTO = new ResponseCourseDTO(result);
            var payload = new Payload<ResponseCourseDTO>() { Status = "Success", Data = resultDTO };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, PostCourseDTO model)
        {
            var result = await repository.Create(
                inclusions: ["Students"],
                model: new Course()
                {
                    Title = model.Title,
                    StartDate = DateTime.Parse(model.StartDate).ToUniversalTime(),
                    AverageGrade = model.AverageGrade
                });

            var resultDTO = new ResponseCourseDTO(result);

            var payload = new Payload<ResponseCourseDTO>() { Status = "Success", Data = resultDTO };
            return TypedResults.Created(_path, payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, PutCourseDTO model)
        {
            var result = await repository.Create(
                inclusions: ["Students"],
                model: new Course()
                {
                    Id = id,
                    Title = model.Title,
                    StartDate = DateTime.Parse(model.StartDate).ToUniversalTime(),
                    AverageGrade = model.AverageGrade
                });

            var resultDTO = new ResponseCourseDTO(result);

            var payload = new Payload<ResponseCourseDTO>() { Status = "Success", Data = resultDTO };
            return TypedResults.Created(_path, payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var result = await repository.Delete(inclusions: ["Students"], model: new Course() { Id = id });
            var resultDTO = new ResponseCourseDTO(result);
            var payload = new Payload<ResponseCourseDTO>() { Data = resultDTO };
            return TypedResults.Ok(payload);
        }
    }
}
