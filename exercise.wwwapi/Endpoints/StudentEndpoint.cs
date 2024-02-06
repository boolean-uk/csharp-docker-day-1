using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var Students = app.MapGroup("Students");
            Students.MapGet("/", GetStudents);
            Students.MapGet("/{id}", GetStudentById);
            Students.MapPost("/createStudent", CreateStudent);
            Students.MapPut("/updateStudent", UpdateStudent);
            Students.MapDelete("/deleteStudent/{id}", DeleteStudent);
            Students.MapPost("/enrollstudent", EnrollStudent);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            IEnumerable<Student> results = await repository.GetStudents();
            return TypedResults.Ok(StudentResponseDTO.FromRepository(results));
        }

        public static async Task<IResult> EnrollStudent(IRepository repository, int studentid, int courseid)
        {
            Student results = await repository.EnrollStudent(studentid, courseid);
            if (results == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(StudentResponseDTO.FromRepository(results));
        }

        public static async Task<IResult> CreateStudent(IRepository repository, StudentPostPayload StudentPostPayload)
        {
            var results = await repository.CreateStudent(StudentPostPayload.firstname, StudentPostPayload.lastname, StudentPostPayload.dateofbirth, StudentPostPayload.avgGrade);

            return TypedResults.Ok(results);
        }

        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var results = await repository.DeleteStudent(id);
            if (results == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(results);
        }

        public static async Task<IResult> GetStudentById(IRepository repository, int id)
        {
            Student results = await repository.GetStudentById(id);
            if (results == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(StudentResponseDTO.FromRepository(results));
        }


        public static async Task<IResult> UpdateStudent(IRepository repository, StudentUpdatePayload StudentUpdatePayload)
        {
            var results = await repository.UpdateStudent(StudentUpdatePayload.id, StudentUpdatePayload.firstname, StudentUpdatePayload.lastname, StudentUpdatePayload.dateofbirth, StudentUpdatePayload.avgGrade);
            if (results == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(results);
        }
    }
}
