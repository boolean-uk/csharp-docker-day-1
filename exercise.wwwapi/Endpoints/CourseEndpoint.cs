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
            students.MapPost("/", CreateCourse);
            students.MapGet("/", GetCourses);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, CoursePost input)
        {
            var entities = await repository.GetAll();

            var entity = new Course(input);
            entity.Id = (entities.Count() == 0 ? 0 : entities.Max(e => e.Id) + 1);
            repository.Insert(entity);
            return TypedResults.Created($"/{entity.Id}", entity);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetAll();

            Payload<List<CourseGet>> payload = new();
            payload.data = new();
            foreach (var result in results)
            {
                payload.data.Add(new CourseGet(result));
            }
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound("Entity not found.");
            }
            var result = repository.Delete(id);
            return result != null ? TypedResults.Ok(result) : Results.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CoursePut input)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound(id);
            }

            entity.CourseTitle = input.CourseTitle != null ? input.CourseTitle : entity.CourseTitle;
            entity.StartDate = (DateTime)(input.StartDate != null ? input.StartDate : entity.StartDate);
            entity.AverageGrade = ((double)(input.AverageGrade != null ? input.AverageGrade : entity.AverageGrade));
            return TypedResults.Created($"/{entity.Id}", entity);
        }
    }
}
