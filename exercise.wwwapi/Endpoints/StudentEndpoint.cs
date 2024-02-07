using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
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
            students.MapGet("/{studentId}", GetStudent);
            students.MapPut("/{studentId}", UpdateStudent);
            students.MapPost("/", CreateStudent);
            students.MapDelete("/{studentId}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, int studentId)
        {
            if (studentId <= 0)
            {
                return TypedResults.BadRequest("id must be positive number above 0");
            }

            var result = await repository.GetStudent(studentId);
            if (result == null)
            {
                return TypedResults.NotFound($"{studentId} is not a valid student id");
            }

            var payload = new Payload<Student>() { data = result };

            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int studentId, StudentUpdateData updateData)
        {
            if (studentId <= 0)
            {
                return TypedResults.BadRequest("id must be positive number above 0");
            }
            if (checkForEmptyOrNull(updateData.FirstName))
            {
                return TypedResults.BadRequest($"First name of the provided data was empty or null");
            }
            if (checkForEmptyOrNull(updateData.LastName))
            {
                return TypedResults.BadRequest($"Last name of the provided data was empty or null");
            }
            if (checkForEmptyOrNull(updateData.DateOfBirth))
            {
                return TypedResults.BadRequest($"Date of birth of the provided data was empty or null");
            }

            
            foreach(int id in updateData.courseIDs)
            {
                if(id <= 0)
                {
                    return TypedResults.BadRequest("id must be positive number above 0");
                }
            }
            
            

            var result = await repository.UpdateStudent(studentId, 
                updateData.FirstName,
                updateData.LastName,
                updateData.DateOfBirth,
                updateData.courseIDs
                
                );

            if (result == null)
            {
                return TypedResults.NotFound("student id or course id were not a valid Id");
            }

            var payload = new Payload<Student>() { data = result };

            return TypedResults.Ok(payload);


        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateStudent(IRepository repository, StudentPayload studentPayload)
        {
            if (checkForEmptyOrNull(studentPayload.FirstName))
            {
                return TypedResults.BadRequest($"First name of the provided data was empty or null");
            }
            if (checkForEmptyOrNull(studentPayload.LastName))
            {
                return TypedResults.BadRequest($"Last name of the provided data was empty or null");
            }
            if (checkForEmptyOrNull(studentPayload.DateOfBirth))
            {
                return TypedResults.BadRequest($"Date of birth of the provided data was empty or null");
            }
            foreach (int id in studentPayload.courseIDs)
            {
                if (id <= 0)
                {
                    return TypedResults.BadRequest("id must be positive number above 0");
                }
            }

            var result = await repository.CreateStudent(
                studentPayload.FirstName,
                studentPayload.LastName,
                studentPayload.DateOfBirth,
                studentPayload.courseIDs
                );
            var payload = new Payload<Student>() { data = result };

            return TypedResults.Ok(payload);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int studentId)
        {
            if (studentId <= 0)
            {
                return TypedResults.BadRequest("id must be positive number above 0");
            }
            var payload = new Payload<Student> { data = await repository.GetStudent(studentId) };
            
            var result = await repository.DeleteStudent(studentId);

            if(result == null)
            {
                return TypedResults.NotFound($"{studentId} is not a valid student id");
            }

            if ((bool)result)
            {
                return TypedResults.Ok(payload);
            }
            else
            {
                return TypedResults.NotFound("could not delete student");
            }

            
        }

        private static bool checkForEmptyOrNull(string updateData)
        {
            if(updateData == null ||updateData == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
  

}
