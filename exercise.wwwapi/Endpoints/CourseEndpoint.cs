using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var courses = app.MapGroup("courses");
            courses.MapGet("/", GetCourses);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var courses = new List<CourseWithStudentsDTO>();
            foreach (Course course in results)
            {
                CourseWithStudentsDTO courseDTO = new CourseWithStudentsDTO()
                {
                    Id = course.Id,
                    Title = course.Title,
                    StartTime = course.StartTime,
                    AverageGrade = course.AverageGrade
                };

                foreach (Student student in course.Students) 
                {
                    StudentWithNoCourseDTO studentDTO = new StudentWithNoCourseDTO()
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DOB = student.DOB
                    };

                    courseDTO.Students.Add(studentDTO);
                }

                courses.Add(courseDTO);
            };

            var payload = new Payload<IEnumerable<CourseWithStudentsDTO>>() { Data = courses };
            return TypedResults.Ok(payload);
        }
    }
}
