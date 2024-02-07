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
        
        //get all students
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
            return TypedResults.Ok(resultList);
        }

        //create student
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentCreatedResponseDTO))]
        public static async Task<IResult> CreateStudent(IRepository repository, 
            StudentPayload createData)
        {
            var student = await repository.CreateStudent(createData);
            if (student == null)
            {
                return TypedResults.BadRequest("All fields are needed");
            }
            StudentCreatedResponseDTO studentToReturn = new StudentCreatedResponseDTO(student);
            return TypedResults.Created("created",studentToReturn);
        }

        //update student
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentCreatedResponseDTO))]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id,
           StudentPayload updateData)
        {
            var student = await repository.UpdateStudent(id, updateData);
            if (student == null)
            {
                return TypedResults.BadRequest("invalid studentID or entry");
            }
            StudentCreatedResponseDTO studentToReturn = new StudentCreatedResponseDTO(student);
            return TypedResults.Created("updated", studentToReturn);
        }

        //delete student
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var student = await repository.DeleteStudent(id);
            if (student == null)
            {
                return TypedResults.BadRequest("invalid studentID");
            }
            StudentCreatedResponseDTO studentToReturn = new StudentCreatedResponseDTO(student);
            return TypedResults.Ok(studentToReturn);
        }
    }
}
