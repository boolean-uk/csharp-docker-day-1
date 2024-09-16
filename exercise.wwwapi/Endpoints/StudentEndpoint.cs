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
            students.MapGet("/{id}", GetStudentById);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var result = await repository.GetStudents();

            if (result == null) { return TypedResults.NotFound(); }

            List<StudentDTOwithcourse> response = new List<StudentDTOwithcourse>();

            foreach(Student student in result)
            {

               StudentDTOwithcourse studentDTO = new StudentDTOwithcourse();
               studentDTO.Id = student.Id;
               studentDTO.FirstName = student.FirstName;
               studentDTO.LastName = student.LastName;
               studentDTO.DateOfBirth = student.DateOfBirth;
               studentDTO.Course = student.Course.CourseTitle;

               response.Add(studentDTO);
            }
            return TypedResults.Ok(response);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> GetStudentById(IRepository repository, int id)
        {
            var student = await repository.GetStudentById(id);

            if (student == null) { return TypedResults.NotFound(); }

            StudentDTOwithcourse studentdto = new StudentDTOwithcourse()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Course = student.Course.CourseTitle,
            };

            return TypedResults.Ok(studentdto);

        }

    }
  

}
