using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapPost("/", CreateStudents);
            students.MapGet("/", GetStudents);
            students.MapPut("/{id}", UpdateStudents);
            students.MapDelete("/{id}", DeleteStudents);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudents(IRepository<Student> repository, StudentPost input)
        {
            var entities = await repository.GetAll();

            var entity = new Student(input);
            entity.Id = (entities.Count() == 0 ? 0 : entities.Max(e => e.Id) + 1);
            repository.Insert(entity);
            return TypedResults.Created($"/{entity.Id}", entity);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();
            Payload<List<StudentGet>> payload = new();
            payload.data = new();
            foreach (var result in results)
            {
                payload.data.Add(new StudentGet(result));
            }
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudents(IRepository<Student> repository, int id)
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
        public static async Task<IResult> UpdateStudents(IRepository<Student> repository, int id, StudentPut input)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound(id);
            }

            entity.FirstName = input.FirstName != null ? input.FirstName : entity.FirstName;
            entity.LastName = input.LastName != null ? input.LastName : entity.LastName;
            entity.DoB = (DateTime)(input.DoB != null ? input.DoB : entity.DoB);
            entity.CourseId = ((int)(input.CourseId != null ? input.CourseId : entity.CourseId));
            await repository.Update(entity);
            return TypedResults.Created($"/{entity.Id}", entity);
        }

    }
}
