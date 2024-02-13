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
            //students.MapPost("/", CreateStudent);
            //students.MapPut("/{id}", UpdateStudent);
            //students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            Payload<List<GetStudentDto>> output = new();
            output.data = new();
            foreach(Student student in await repository.Get())
            {
                output.data.Add(new GetStudentDto(student));
            }
            return TypedResults.Ok(output);
        }

    }
  

}
