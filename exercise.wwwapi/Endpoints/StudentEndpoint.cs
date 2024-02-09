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
            students.MapGet("/", GetStudents);
            students.MapGet("/{id}", GetStudentByID);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var students = await repository.GetStudents();
            List<StudentDTO> results = new List<StudentDTO>();
            foreach (var student in students)
            {
                results.Add(new StudentDTO(student));
            }
            var payload = new Payload<IEnumerable<StudentDTO>>() { data = results };
            return TypedResults.Ok(payload);
        }
        public static async Task<IResult> GetStudentByID(IRepository repository, int id)
        {
            Student? result = await repository.GetStudentByID(id);
            if (result is null) return TypedResults.NotFound();
            return TypedResults.Ok(new Payload<StudentDTO>() { data = new StudentDTO(result) });
        }
        public static async Task<IResult> CreateStudent(IRepository repository, StudentPayload payload)
        {
            Student student = await repository.CreateStudent(payload.firstName, payload.lastName, payload.dateOfBirth);
            return TypedResults.Ok(new Payload<StudentDTO>() { data = new StudentDTO(student) });
        }
        public static async Task<IResult> UpdateStudent(IRepository repository, StudentPayload payload ,int id)
        {
            Student? result = await repository.GetStudentByID(id);
            if (result is null) return TypedResults.NotFound();
            Student student = await repository.UpdateStudent(result, payload.firstName, payload.lastName, payload.dateOfBirth);
            return TypedResults.Ok(new Payload<StudentDTO>() { data = new StudentDTO(student) });

        }
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            Student? result = await repository.GetStudentByID(id);
            if (result is null) return TypedResults.NotFound();
            repository.DeleteStudent(result);
            return TypedResults.Ok(new Payload<StudentDTO>() { data = new StudentDTO(result) });
        }



    }
  

}
