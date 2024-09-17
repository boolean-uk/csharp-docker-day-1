using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModels;
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
            students.MapPost("/students", CreateStudent);
            students.MapPut("students", UpdateStudent);
            //students.MapDelete("students", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            var result = await repository.GetStudents();

            if (result == null) { return TypedResults.NotFound(); }

            List<StudentDTOwithcourse> response = new List<StudentDTOwithcourse>();

            foreach (Student student in result)
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

        public static async Task<IResult> GetStudentById(IStudentRepository repository, int id)
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateStudent(IStudentRepository repository, StudentPostModel model)
        {
            try
            {
                var addedstudent = await repository.CreateStudent(new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    CourseId = model.CourseId,

                });
                if (addedstudent == null) { return TypedResults.NotFound(); }

                StudentDTOwithcourse studentDTOwithcourse = new StudentDTOwithcourse()
                {
                    Id = addedstudent.Id,
                    FirstName = addedstudent.FirstName,
                    LastName = addedstudent.LastName,
                    DateOfBirth = addedstudent.DateOfBirth,
                    Course = addedstudent.Course.CourseTitle,
                };
                return TypedResults.Ok(studentDTOwithcourse);

            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> UpdateStudent(IStudentRepository repository, int id, StudentPutModel model)
        {
            try
            {
                var updatedstudent = await repository.GetStudentById(id);

                if (updatedstudent == null) { return TypedResults.NotFound(); }

                updatedstudent.FirstName = model.FirstName;
                updatedstudent.LastName = model.LastName;
                updatedstudent.DateOfBirth = model.DateOfBirth;
                updatedstudent.CourseId = model.CourseId;

                var updatestudent = await repository.UpdateStudent(updatedstudent);

                return TypedResults.Ok(updatedstudent);

            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);

            }



        }
       /* public static async Task<IResult> DeleteStudent(IStudentRepository repository) */
    }
}
    
  


