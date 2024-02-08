using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static exercise.wwwapi.DataModels.Payloads.StudentPayloads;

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
            students.MapPut("{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPost("/{student_id}/course/{course_id}", AddStudentToCourse);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.getStudents();
            if (results == null)
            {
                return TypedResults.NotFound("There are no users in the database");
            }
            var payload = new List<StudentDTO>();
            foreach (var student in results) {
                payload.Add(new StudentDTO(student));
            }
            var dataDTO = new StudentListDataDTO(payload, "success");
            //var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(dataDTO);
        }
        private static async Task<IResult> CreateStudent(StudentPostPayload payload, IRepository repository)
        {
            if (payload.first_name == null || payload.first_name == "")
            {
                return TypedResults.BadRequest($"First name must be a non-empty value! You entered: {payload.first_name}");
            }
            if (payload.last_name == null || payload.last_name == "")
            {
                return TypedResults.BadRequest($"Last name must be a non-empty value! You entered: {payload.last_name}");
            }
            if (payload.d_o_b == null)
            {
                return TypedResults.BadRequest($"Yout date of birth must be a non-empty value! You entered: {payload.d_o_b}");
            }

            var result = await repository.createStudent(payload.first_name, payload.last_name, payload.d_o_b);

            if (result == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Created("/students", new StudentDataDTO(result, "success"));
        }

        private static async Task<IResult> UpdateStudent(int id, StudentPutPayload payload, IRepository repository)
        {
            if (payload.first_name == "")
            {
                return TypedResults.BadRequest("Updated students first name can not be of type empty");
            }
            if (payload.last_name == "")
            {
                return TypedResults.BadRequest("Updated students last name can not be of type empty");
            }
            
            var result = await repository.updateStudent(id, payload.first_name, payload.last_name, payload.d_o_b);
            if (result == null)
            {
                return TypedResults.NotFound($"User with id: {id} could not be found");
            }
            return TypedResults.Created($"/customers/{id}", new StudentDataDTO(result, "success"));
        }

        private static async Task<IResult> DeleteStudent(int id, IRepository repository)
        {
            var result = await repository.deleteStudent(id);
            if (result == null)
            {
                return TypedResults.NotFound($"User with id: {id} could not be found");
            }
            return TypedResults.Ok(new StudentDataDTO(result, "success"));

        }

        private static async Task<IResult> AddStudentToCourse(int student_id, int course_id, IRepository repository)
        {
            var result = await repository.addStudentToCourse(student_id, course_id);

            if (result)
            {
                return TypedResults.Created($"Student with od {student_id} has successfuly been added to course with id {course_id}");
            } else
            {
                return TypedResults.BadRequest($"Given values is not in the database");
            }
        }

    }
  

}
