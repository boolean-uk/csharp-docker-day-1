using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Payloads;
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
            students.MapGet("/GetAllStudents", GetStudents);
            students.MapGet("/GetStudentById/{id}", GetStudent);
            students.MapPost("/CreateStudent", CreateStudent);
            students.MapPut("/UpdateStudent/{id}", UpdateStudentById);
            students.MapDelete("DeleteStudent/{id}", DeleteStudentById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudentById(IRepository repository, int studentId)
        {
            try
            {
                var results = await repository.DeleteStudent(studentId);
                var payload = new Payload<StudentDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudentById(IRepository repository, int studentId, StudentPayload studentPayload)
        {
            try
            {
                var results = await repository.UpdateStudent(studentId, studentPayload);
                var payload = new Payload<StudentDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, StudentPayload studentPayload)
        {
            try
            {
                var results = await repository.CreateStudent(studentPayload);
                var payload = new Payload<StudentDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, int studentId)
        {
            try
            {
                var results = await repository.GetStudent(studentId);
                var payload = new Payload<StudentDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<StudentDTO>>() { Data = results };
            return TypedResults.Ok(payload);
        }

    }
  

}
