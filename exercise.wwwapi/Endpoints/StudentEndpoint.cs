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
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, CreateStudentDTO StudentDTO)
        {
            try
            {
                Student Student = new()
                {
                    
                };
                var results = await repository.CreateStudent(Student);
                return TypedResults.Created();

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, CreateStudentDTO createStudentDTO, int id)
        {
            try
            {
                var result = await repository.UpdateStudent(createStudentDTO, id);
                return TypedResults.Created("Created", result);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            try
            {
                var result = await repository.DeleteStudent(id);
                return TypedResults.Ok(result);
            }
            catch
            {
                return TypedResults.BadRequest();
            }
        }

    }
  

}
