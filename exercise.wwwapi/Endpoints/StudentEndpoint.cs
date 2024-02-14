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
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapPost("/", CreateStudent);
        }

        private static async Task<IResult> CreateStudent(IRepository repository, StudentPost studentPost)
        {
            var createdStudent = await repository.CreateStudent(studentPost);

            if (createdStudent != null)
            {
                var payload = new Payload<Student>() { data = createdStudent };
                return TypedResults.Ok(payload);
            }
            else
            {  return TypedResults.BadRequest();}

           
        }

        private static async Task<IResult> UpdateStudent(IRepository repository, int id, Student updatedStudent)
        {
            var result = await repository.UpdateStudent(id, updatedStudent);

            if (result == null)
            {
               
                return TypedResults.NotFound();
            }

            var payload = new Payload<Student>() { data = result };
          
            return TypedResults.Ok(payload);
        }

        private static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var deletedStudent = await repository.DeleteStudent(id);
            var payload = new Payload<Student>() { data = deletedStudent };
           
            return TypedResults.Ok(payload);
        }

        

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
        
            return TypedResults.Ok(results);
        }

    }
  

}
