using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Helpers;
using exercise.wwwapi.Interfaces;
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
            students.MapPost("/", PostStudent);
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{id}", GetStudentById);
            students.MapPut("/{id}", UpdateStudentById);
            students.MapDelete("/{id}", DeleteStudentById);
        }

        public static async Task<IResult> PostStudent(IRepository<Student> studentRepo, IRepository<Course> courseRepo, StudentPost model)
        {
            var course = await courseRepo.SelectById(model.CourseId);
            if (course == null)
            {
                return TypedResults.BadRequest("Could not find course");
            }

            var newInsert = await studentRepo.Insert(DTOHelper.EntityMapper<Student>(model));
            //If something fails 

            if (newInsert == null)
            {
                return TypedResults.BadRequest("Could not insert student");
            }

            var studentDTO = DTOHelper.EntityMapper<StudentDTO>(newInsert, new List<string> { "Course" });
            var courseDTO = DTOHelper.EntityMapper<CourseDTO>(course);
            studentDTO.Course = courseDTO;

            var payload = new Payload<StudentDTO>()
            {
                data = studentDTO
            };

            return TypedResults.Created($"/{studentDTO.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllStudents(IRepository<Student> studentRepo, IRepository<Course> courseRepo)
        {
            var results = await studentRepo.SelectAll();
            List<StudentDTO> studentDTOs = new List<StudentDTO>();

            if(results == null)
            {
                return TypedResults.NotFound("Could not find any students");
            }

            //For each Student class, map it to a StudentDTO class and add it to the list WITH a CourseDTO
            foreach (var student in results)
            {
                var studentDTO = DTOHelper.EntityMapper<StudentDTO>(student, new List<string> { "Course" });

                // Fetch the corresponding course from the repository
                var course = await courseRepo.SelectById(student.CourseId);
                // Map the course object to a CourseDTO object
                var courseDTO = DTOHelper.EntityMapper<CourseDTO>(course);
                // Assign the CourseDTO object to the Course property of StudentDTO
                studentDTO.Course = courseDTO;

                studentDTOs.Add(studentDTO);
            }

            var payload = new Payload<IEnumerable<StudentDTO>>() { data = studentDTOs };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentById(IRepository<Student> studentRepo, IRepository<Course> courseRepo, int id)
        {
            var student = await studentRepo.SelectById(id);
            var course = await courseRepo.SelectById(student.CourseId);
            if(student == null)
            {
                return TypedResults.NotFound("Could not find student");
            }
            if(course == null)
            {
                return TypedResults.NotFound("Could not find course");
            }

            var studentDTO = DTOHelper.EntityMapper<StudentDTO>(student, new List<string> { "Course" });
            var courseDTO = DTOHelper.EntityMapper<CourseDTO>(course);
            studentDTO.Course = courseDTO;
            var payload = new Payload<StudentDTO>() { data = studentDTO };

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudentById(IRepository<Student> studentRepo, IRepository<Course> courseRepo, int id, StudentPut model)
        {
            var course = await courseRepo.SelectById(model.CourseId);
            if (course == null)
            {
                return TypedResults.NotFound("Could not find course");
            }

            var newUpdate = await studentRepo.Update(id, DTOHelper.EntityMapper<Student>(model));
            if(newUpdate == null)
            {
                return TypedResults.NotFound("Could not find student");
            }

            var studentDTO = DTOHelper.EntityMapper<StudentDTO>(newUpdate, new List<string> { "Course" });
            var payload = new Payload<StudentDTO>
            {
                data = studentDTO
            };

            return TypedResults.Created($"/{studentDTO.Id}", newUpdate);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudentById(IRepository<Student> studentRepo, IRepository<Course> courseRepo, int id)
        {
            var result = await studentRepo.Delete(id);
            var course = await courseRepo.SelectById(result.CourseId);
            if(result == null)
            {
                return TypedResults.NotFound("Could not find student");
            }
            var studentDTO = DTOHelper.EntityMapper<StudentDTO>(result, new List<string> { "Course" });
            var courseDTO = DTOHelper.EntityMapper<CourseDTO>(course);
            studentDTO.Course = courseDTO;
            var payload = new Payload<StudentDTO>() { data = studentDTO };
            return TypedResults.Ok(payload);
        }

    }
  

}
