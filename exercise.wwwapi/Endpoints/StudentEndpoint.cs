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
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents([FromServices] IRepository repository)
        {

            var results = await repository.GetStudents();
            var students = results.OrderBy(x => x.Id).Select(x => new StudentDto(x)).ToList();
            var payload = new Payload<List<StudentDto>>() { data = students }; // Change the type of payload
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent([FromServices] IRepository repository, [FromBody]Student student)
        {
            var results = await repository.CreateStudent(student);
            StudentDto newStudent = new StudentDto(results);

            var payload = new Payload<StudentDto>() { data = newStudent };
            return TypedResults.Created($"/appointment {results.Id}", payload);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent([FromServices] IRepository repository,StudentPayload studentpayload, int id)
        {
           
            var updatedStudent = await repository.UpdateStudent(id,  studentpayload);
            if (updatedStudent == null)
            {
                return TypedResults.NotFound("student with the given id does not exist");
            }


            StudentDto updatedStudentDto = new StudentDto(updatedStudent);

            var payload = new Payload<StudentDto>() { data = updatedStudentDto };
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent([FromServices] IRepository repository, int id)
        {

            var removedStudent = await repository.DeleteStudent(id);
            if (removedStudent == null)
            {
                return TypedResults.NotFound("student with the given id does not exist");
            }

            StudentDto newStudent = new StudentDto(removedStudent);

            var payload = new Payload<StudentDto>() { data = newStudent };
            return TypedResults.Ok(payload);

        }







    }
  

}
