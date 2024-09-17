using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

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
            students.MapPost("/", AddStudents);
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        private static async Task<IResult> AddStudents(IRepository repository, StudentPostModel model)
        {

            var payload = new Payload<Student>();

            payload.Data = await repository.AddStudent(new Student() { 
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                CourseId = model.CourseId

            });

            return TypedResults.Ok(new {Data  = payload.Data });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository, StudentPostModel model, int id)
        {
            Payload<Student> response = new Payload<Student>();
            try
            {
                var targetList = await repository.GetStudents();
                var target = targetList.FirstOrDefault(s => s.Id == id);

                target.FirstName = string.IsNullOrEmpty(model.FirstName) ? target.FirstName : model.FirstName;
                target.LastName = string.IsNullOrEmpty(model.LastName) ? target.LastName : model.LastName;
                target.DOB = string.IsNullOrEmpty(model.DOB.ToString()) ? target.DOB : model.DOB;


                response.Data = await repository.UpdateStudent(target);
                return TypedResults.Ok(new {Data = response.Data});
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var results = await repository.DeleteStudent(id);
            var payload = new Payload<Student>() { Data = results };
            return TypedResults.Ok(new {payload.Data });
        }

    }
}