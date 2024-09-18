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
            students.MapPost("/", AddStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAStudent(IRepository repository, int id)
        {
            Student result = await repository.GetAStudent(id);
            if(result != null)
            {
                return TypedResults.Ok(new { FirstName = result.FirstName, LastName = result.LastName, DateOfBirth = result.DOT });
            }
            return TypedResults.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IRepository repository, StudentPostModel model)
        {
            try
            {
                
                Course course = await repository.GetACourse(model.CourseID);
                if(course == null)
                {
                    return TypedResults.NotFound();
                }
                Student student = new Student() { FirstName = model.FirstName, LastName = model.LastName, DOT = model.DOT, CourseID = model.CourseID };
                var result = await repository.AddStudent(student);
                Payload<Student> payload = new Payload<Student>() { Data = result };
                return TypedResults.Ok(payload);
            }
            catch
            {
                return Results.BadRequest();
            }
        }

    }
  

}
