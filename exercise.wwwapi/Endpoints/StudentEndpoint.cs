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
            students.MapPut("/update/{id}", UpdateStudent);
            students.MapPost("/add", AddStudent);
            students.MapDelete("/delete/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.Get();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, IRepository<Student> repo, int id, StudentDTO inStudent)
        {
            var existingData = await repository.GetById(id);

            if (existingData == null) return TypedResults.NotFound();

            if (inStudent.FirstName != "string") existingData.FirstName = inStudent.FirstName;
            if (inStudent.LastName != "string") existingData.LastName = inStudent.LastName;
            if (inStudent.AverageScore != 0) existingData.AverageScore = inStudent.AverageScore;
            if (inStudent.CourseStart != null) existingData.CourseStart = inStudent.CourseStart;
            if (inStudent.Dob != null) existingData.Dob = inStudent.Dob;

            var course = await repo.GetById(existingData.CourseId);
            if (course == null) return TypedResults.NotFound("Course was not found! Check that CourseId is correct.");

            var results = await repository.Update(existingData);
            var payload = new Payload<Student>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddStudent(IRepository<Student> repository, IRepository<Course> repo, StudentDTO inStudent)
        {
            Student student = new Student()
            {
                FirstName = inStudent.FirstName, LastName = inStudent.LastName, AverageScore = inStudent.AverageScore,
                CourseStart = inStudent.CourseStart,
                Dob = inStudent.Dob,
                CourseId = inStudent.CourseId
            };

            var course = await repo.GetById(student.CourseId);
            if (course == null) return TypedResults.NotFound("Course was not found!  Check that CourseId is correct.");
            student.CourseTitle = course.CourseName;

            var results = await repository.Insert(student);
            var payload = new Payload<Student>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var results = await repository.Delete(id);
            var payload = new Payload<Student>() { data = results };
            return TypedResults.Ok(payload);
        }
    }
  

}
