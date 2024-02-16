using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentCoursesEndpoint
    {
        public static void StudentCoursesEndpointConfiguration(this WebApplication app)
        {
            var studentCourses = app.MapGroup("/studentcourses");

            studentCourses.MapPost("/", AddCourseToStudent);
            studentCourses.MapDelete("/{studentId}/{courseId}", RemoveCourseFromStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddCourseToStudent(
            IRepository<StudentCourse> studentCourseRepo,
            IRepository<Student> studentRepo,
            IRepository<Course> courseRepo,
            StudentCourseDto studentCourseDto
            )
        {
            var student = await studentRepo.GetById(studentCourseDto.StudentId);
            var course = await courseRepo.GetById(studentCourseDto.CourseId);
            var studentCourse = new StudentCourse
            {
                StudentId = studentCourseDto.StudentId,
                CourseId = studentCourseDto.CourseId,
                Student = student,
                Course = course
            };

            var result = await studentCourseRepo.Insert(studentCourse);
            if (result == null)
            {
                return TypedResults.BadRequest("Invalid student or course ID.");
            }

            var payload = new Payload<StudentOutputDto> { data = StudentOutputDto.Create(student) };
            return TypedResults.Created($"/studentcourses/{studentCourseDto.StudentId}/{studentCourseDto.CourseId}", payload);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> RemoveCourseFromStudent(IRepository<StudentCourse> repository, int studentId, int courseId)
        {
            var student = repository.GetById(studentId, courseId);
            var success = await repository.Delete(student);
            if (success == null)
            {
                return TypedResults.NotFound($"Course {courseId} is not assigned to student {studentId}.");
            }
            return TypedResults.NoContent();
        }

    }
}
