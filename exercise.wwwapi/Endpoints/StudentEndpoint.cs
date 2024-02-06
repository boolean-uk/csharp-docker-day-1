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
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var resultList = new List<StudentResponseDTO>();
            var results = await repository.GetStudents();

            foreach (var student in results)
            {
                StudentResponseDTO studentToReturn = new StudentResponseDTO(student);
                resultList.Add(studentToReturn);
            }
            //var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(resultList);
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentResponseDTO))]
        public static async Task<IResult> CreateStudent(IRepository repository, 
            CreateNewStudentPayload createData)
        {
            var student = await repository.CreateStudent(createData);
            StudentResponseDTO studentToReturn = new StudentResponseDTO(student);
            return TypedResults.Created("created",studentToReturn);
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentResponseDTO))]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id,
           UpdateStudentPayload createData)
        {
            var student = await repository.UpdateStudent(id, createData);
            StudentResponseDTO studentToReturn = new StudentResponseDTO(student);
            return TypedResults.Created("updated", studentToReturn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var student = await repository.DeleteStudent(id);
            StudentResponseDTO studentToReturn = new StudentResponseDTO(student);
            return TypedResults.Ok(studentToReturn);
        }
    }
}
