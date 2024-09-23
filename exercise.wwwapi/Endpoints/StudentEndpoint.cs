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
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var students = new List<StudentWithCourseDTO>();
            foreach (Student student in results)
            {
                StudentWithCourseDTO studentWithCourseDTO = new StudentWithCourseDTO() 
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DOB = student.DOB,
                    Course = new CourseWithNoStudentsDTO() 
                    {
                        Id = student.Course.Id,
                        Title = student.Course.Title,
                        StartTime = student.Course.StartTime,
                        AverageGrade = student.Course.AverageGrade
                    }
                };

                students.Add(studentWithCourseDTO);
            }
            var payload = new Payload<IEnumerable<StudentWithCourseDTO>>() { Data = students };
            return TypedResults.Ok(payload);
        }
    }
}
