using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.InputDTOs;
using exercise.wwwapi.DataTransferObjects.Students;
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
            students.MapGet("/{id}", GetStudent);
            students.MapPost("/", PostStudent);
            students.MapPut("/{id}", PutStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repo)
        {
            IEnumerable<Student> students = await repo.GetAll();

            IEnumerable<StudentDTO> studentsOut = students.Select(s => new StudentDTO(s));
            Payload<IEnumerable<StudentDTO>> payload = new Payload<IEnumerable<StudentDTO>>() { data = studentsOut };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IRepository<Student> repo, int id)
        {
            Student? student = await repo.Get(id);
            if (student == null) 
            {
                return TypedResults.NotFound($"No student with ID {id} found.");
            }

            StudentDTO studentOut = new StudentDTO(student);
            Payload<StudentDTO> payload = new Payload<StudentDTO>() { data = studentOut };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> PostStudent(IRepository<Student> repo, IRepository<Course> courseRepo, StudentInputPostDTO studentPost)
        {
            DateTime dob;
            try
            {
                dob = (DateTime)studentPost.DateOfBirth;
            } catch (FormatException fe) 
            {
                return TypedResults.BadRequest($"Could not interpret the provided DateOfBirth, {studentPost.DateOfBirth}.");
            }

            Student student = new Student()
            {
                FirstName = studentPost.FirstName, 
                LastName = studentPost.LastName,
                DateOfBirth = DateTime.SpecifyKind(dob, DateTimeKind.Utc),
                CourseID = studentPost.CourseId,
                AverageGrade = studentPost.AverageGrade,
            };

            Student createdStudent = await repo.Insert(student);
            Course? course = await courseRepo.Get(createdStudent.CourseID);
            createdStudent.Course = course;

            StudentDTO studentOut = new StudentDTO(createdStudent);
            Payload<StudentDTO> payload = new Payload<StudentDTO>() { data = studentOut };
            return TypedResults.Created($"/{createdStudent.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> PutStudent(IRepository<Student> repo, int id, StudentInputPutDTO studentPost)
        {
            Student? student = await repo.Get(id);
            if (student == null)
            {
                return TypedResults.NotFound($"No student with ID {id} found.");
            }

            DateTime dob;
            if (studentPost.DateOfBirth != null) 
            {
                dob = (DateTime)studentPost.DateOfBirth;
            }
            else 
            {
                dob = student.DateOfBirth;
            }

            Student transcribedStudent = new Student()
            {
                Id = id,
                FirstName = studentPost.FirstName ?? student.FirstName,
                LastName = studentPost.LastName ?? student.LastName,
                DateOfBirth = DateTime.SpecifyKind(dob, DateTimeKind.Utc),
                CourseID = studentPost.CourseId ?? student.CourseID,
                AverageGrade = studentPost.AverageGrade ?? student.AverageGrade
            };

            Student createdStudent = await repo.Update(id, transcribedStudent);

            StudentDTO studentOut = new StudentDTO(createdStudent);
            Payload<StudentDTO> payload = new Payload<StudentDTO>() { data = studentOut };
            return TypedResults.Created($"/{createdStudent.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repo, int id)
        {
            Student? student = await repo.Get(id);
            if (student == null)
            {
                return TypedResults.NotFound($"No student with ID {id} found.");
            }

            Student deletedStudent = await repo.Delete(id);

            StudentDTO studentOut = new StudentDTO(deletedStudent);
            Payload<StudentDTO> payload = new Payload<StudentDTO>() { data = studentOut };
            return TypedResults.Ok(payload);
        }
    }
}
