using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
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
            students.MapGet("/", GetStudents);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", EditStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> CreateStudent(IRepository repo, StudentDTO dto)
        {
            var payload = new Payload<Student>();
            Student student = new Student()
            {
                Name = dto.Name
            };
            await repo.CreateStudent(student);

            payload.Data = student;
            return TypedResults.Ok(payload);
            
        }

        public static async Task<IResult> DeleteStudent(IRepository repo, int id)
        {
            var payload = new Payload<Student>();
            Student student = await repo.GetStudentById(id);
            await repo.DeleteStudent(student);

            payload.Data = student;

            return TypedResults.Ok(payload);
        }

        public static async Task<IResult>EditStudent(IRepository repo, StudentDTO dto, int id)
        {
            var payload = new Payload<Student>();
            Student student = await repo.GetStudentById(id);
            await repo.EditStudent(student, dto.Name);
            payload.Data = student;
            return TypedResults.Ok(payload);
        }
    }
  

}
