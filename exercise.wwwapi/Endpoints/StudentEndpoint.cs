using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.DTO;
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
            students.MapPost("/", AddStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent); 
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var entities = await repository.GetStudents();

            List<StudentDto> students = new List<StudentDto>();

            foreach(var entity in entities)
            {
                var student = new StudentDto()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    DateOfBirth = entity.DateOfBirth,
                    AverageGrade = entity.AverageGrade,
                    Courses = entity.Courses.Select(x => new CourseListDto()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        StartDate = x.StartDate,
                    }).ToList(),
                };
                students.Add(student);
            }

            Payload<List<StudentDto>> result = new Payload<List<StudentDto>>();
            result.data = students;
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentById(IRepository repository, int id)
        {
            var entities = await repository.GetStudents();
            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Student not found");
            }
            var entity = await repository.GetStudentById(id);
            var student = new StudentDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth,
                AverageGrade = entity.AverageGrade,
                Courses = entity.Courses.Select(x => new CourseListDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    StartDate = x.StartDate,
                }).ToList(),
            };


            Payload<StudentDto> result = new Payload<StudentDto>();
            result.data = student;
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, AddStudentDto student)
        {
            Student entity = new Student();
            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;
            entity.DateOfBirth = student.DateOfBirth;
            entity.AverageGrade = student.AverageGrade;

            var studentDto = new StudentDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth,
                AverageGrade = entity.AverageGrade,
            };


            Payload<StudentDto> result = new Payload<StudentDto>();
            result.data = studentDto;
            return TypedResults.Created(nameof(AddStudent), result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository, AddStudentDto student, int id)
        {
            var entities = await repository.GetStudents();
            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Student not found");
            }

            var entity = await repository.GetStudentById(id);

            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;
            entity.DateOfBirth = student.DateOfBirth;
            entity.AverageGrade = student.AverageGrade;

            await repository.UpdateStudent(entity, id);

            var studentDto = new StudentDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth,
                AverageGrade = entity.AverageGrade,
                Courses = entity.Courses.Select(x => new CourseListDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    StartDate = x.StartDate,
                }).ToList(),
            };

            Payload<StudentDto> result = new Payload<StudentDto>();
            result.data = studentDto;

            return TypedResults.Ok(entity);
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var entities = await repository.GetStudents();
            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Student not found");
            }
            var entity = await repository.GetStudentById(id);

            var studentDto = new StudentDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth,
                AverageGrade = entity.AverageGrade,
                Courses = entity.Courses.Select(x => new CourseListDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    StartDate = x.StartDate,
                }).ToList(),
            };
            await repository.DeleteStudent(id);

            Payload<StudentDto> result = new Payload<StudentDto>();
            result.data = studentDto;

            return TypedResults.Ok(entity);
        }


    }
  

}
