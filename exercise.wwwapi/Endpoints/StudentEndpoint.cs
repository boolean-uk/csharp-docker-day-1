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

            students.MapGet("", GetStudents);
            students.MapGet("{id}", GetStudentByID);
            students.MapPut("{id}", UpdateStudent);
            students.MapPost("", CreateStudent);
            students.MapDelete("{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();
            Payload<IEnumerable<Student>> payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentByID(IRepository<Student> repository, int id)
        {
            var results = await repository.GetByID(id);
            Payload<Student> payload = new Payload<Student>() { data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, Student newStudent)
        {
            var results = await repository.Insert(newStudent);
            Payload<Student> payload = new Payload<Student>() { data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int studentId, Student updatedStudent)
        {
            var results = await repository.Update(studentId, updatedStudent);
            Payload<Student> payload = new Payload<Student>() { data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            Payload<Student> payload = new Payload<Student>() { data = await repository.Delete(id) };
            return TypedResults.Ok(payload);
        }
    }
  

}
