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
            students.MapGet("/{id}", GetStudent);
            students.MapPost("", AddStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();
            var payload = new Payload<IEnumerable<StudentResponse>>() { Data = Student.ToResponseDTO(results) };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IRepository<Student> repository, int id)
        {
            var results = await repository.Get(id);
            if (results == null)
            {
                return TypedResults.NotFound($"Student with id {id} was not found");
            }
            var payload = new Payload<StudentResponse>() { Data = Student.ToResponseDTO(results) };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddStudent(IRepository<Student> studentRepository, IRepository<Course> courseRepository, StudentPost student)
        {
            if (student == null)
            {
                return TypedResults.BadRequest("Invalid input: missing student");
            }
            if (string.IsNullOrEmpty(student.FirstName))
            {
                return TypedResults.BadRequest("Invalid input: please enter a first name");
            }
            if (string.IsNullOrEmpty(student.LastName))
            {
                return TypedResults.BadRequest("Invalid input: please enter a last name");
            }
            if (student.DateOfBirth == null)
            {
                return TypedResults.BadRequest("Invalid input: please enter a date of birth");
            }
            if (student.CourseId == null)
            {
                return TypedResults.BadRequest("Invalid input: please enter a course id");
            }
            if (student.StartDate == null)
            {
                return TypedResults.BadRequest("Invalid input: please enter a start date");
            }
            if (student.AverageGrade == null)
            {
                return TypedResults.BadRequest("Invalid input: please enter an average grade");
            }

            var course = await courseRepository.Get(student.CourseId.Value);
            if (course == null)
            {
                return TypedResults.NotFound($"Course with course id {student.CourseId.Value} not found");
            }

            Student newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth.Value,
                CourseId = student.CourseId.Value,
                Course = course,
                StartDate = student.StartDate.Value,
                AverageGrade = student.AverageGrade.Value
            };

            var addedStudent = await studentRepository.Add(newStudent);
            var studentDTO = Student.ToResponseDTO(newStudent);
            var payload = new Payload<StudentResponse> { Data = studentDTO };

            return TypedResults.Created($"/{addedStudent.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> studentRepo, IRepository<Course> courseRepo, int id, StudentPost student)
        {
            if (student == null)
            {
                return TypedResults.BadRequest("Invalid input: missing student");
            }

            Student? oldStudent = await studentRepo.Get(id);

            if (oldStudent == null)
            {
                return TypedResults.BadRequest($"Student with id {id} could not be found");
            }

            if (!string.IsNullOrEmpty(student.FirstName)) { oldStudent.FirstName = student.FirstName; }
            if (!string.IsNullOrEmpty(student.LastName)) { oldStudent.LastName = student.LastName; }
            if (student.CourseId != null) 
            {
                var course = await courseRepo.Get(student.CourseId.Value);
                if (course == null)
                {
                    return TypedResults.NotFound($"Course with id {student.CourseId.Value} was not found");
                }
                oldStudent.CourseId = student.CourseId.Value;
                oldStudent.Course = course;
            }
            if (student.DateOfBirth != null) { oldStudent.DateOfBirth = student.DateOfBirth.Value; }
            if (student.StartDate != null) { oldStudent.StartDate = student.StartDate.Value; }
            if (student.AverageGrade != null) { oldStudent.AverageGrade = student.AverageGrade.Value; }

            var changedStudent = await studentRepo.Update(oldStudent);
            var payload = new Payload<StudentResponse> { Data = Student.ToResponseDTO(changedStudent) };

            return TypedResults.Created($"/{id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var deletedStudent = await repository.Delete(id);
            if (deletedStudent == null)
            {
                return TypedResults.NotFound($"Student with id {id} was not found");
            }
            
            var payload = new Payload<StudentResponse> { Data = Student.ToResponseDTO(deletedStudent) };

            return TypedResults.Ok(payload);
        }
    }
}
