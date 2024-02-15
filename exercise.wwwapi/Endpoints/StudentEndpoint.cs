using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.Request;
using exercise.wwwapi.DataTransferObjects.Response;
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
            students.MapGet("/", GetAll);
            students.MapGet("/{id}", GetById);
            students.MapPut("/{id}", UpdateById);
            students.MapPost("/", Create);
            students.MapDelete("/{id}", DeleteById);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAll(IRepository<Student> repository)
        {
            var students = await repository.GetAll();
            List<StudentResponseDTO> response = new List<StudentResponseDTO>();
            foreach (var student in students)
            {
                response.Add(new StudentResponseDTO()
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    AverageGrade = student.AverageGrade,
                    CourseTitle = student.Course.Title
                });
            }
            return TypedResults.Ok(new Payload<List<StudentResponseDTO>>() { data = response });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetById(IRepository<Student> studentRepository, int id)
        {
            Student? student = await studentRepository.GetById(id);
            if (student == null) return TypedResults.NotFound($"No student with id={id}");
            StudentResponseDTO response = new StudentResponseDTO()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AverageGrade = student.AverageGrade,
                CourseTitle = student.Course.Title
            };
            return TypedResults.Ok(new Payload<StudentResponseDTO>() { data = response });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteById(IRepository<Student> studentRepository, int id)
        {
            Student? student = await studentRepository.DeleteById(id);
            if (student == null) return TypedResults.NotFound($"No student with id={id}");
            StudentResponseDTO response = new StudentResponseDTO()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AverageGrade = student.AverageGrade,
                CourseTitle = student.Course.Title
            };
            return TypedResults.Ok(new Payload<StudentResponseDTO>() { data = response });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> UpdateById(IRepository<Student> studentRepository, IRepository<Course> courseRepository, int id, StudentRequestDTO request)
        {
            Student? student = await studentRepository.GetById(id);
            if (student == null) return TypedResults.NotFound($"No student with id={id}");
            Course? course = await courseRepository.GetById(request.CourseId);
            if (course == null) return TypedResults.BadRequest($"No course with id={request.CourseId}");
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.DateOfBirth = DateTime.SpecifyKind(request.DateOfBirth, DateTimeKind.Utc);
            student.AverageGrade = request.AverageGrade;
            student.CourseId = course.Id;
            student = await studentRepository.Update(student);
            StudentResponseDTO response = new StudentResponseDTO()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AverageGrade = student.AverageGrade,
                CourseTitle = student.Course.Title
            };
            return TypedResults.Created($"{student.Id}", new Payload<StudentResponseDTO>() { data = response });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> Create(IRepository<Student> studentRepository, IRepository<Course> courseRepository, StudentRequestDTO request)
        {
            Course? course = await courseRepository.GetById(request.CourseId);
            if (course == null) return TypedResults.BadRequest($"No course with id={request.CourseId}");
            Student newStudent = await studentRepository.Insert(new Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = DateTime.SpecifyKind(request.DateOfBirth, DateTimeKind.Utc),
                CourseId = course.Id,
                AverageGrade = request.AverageGrade
            });
            StudentResponseDTO response = new StudentResponseDTO()
            {
                Id = newStudent.Id,
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                DateOfBirth = newStudent.DateOfBirth,
                AverageGrade = newStudent.AverageGrade,
                CourseTitle = newStudent.Course.Title
            };
            return TypedResults.Created($"/{newStudent.Id}", new Payload<StudentResponseDTO>() { data = response });
        }

    }
  

}
