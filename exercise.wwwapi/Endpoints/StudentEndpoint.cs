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
            students.MapGet("/{id}", GetStudentById);
            students.MapPost("/", AddStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPut("/{id}", UpdateStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();
            
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
           
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetStudentById(IRepository<Student> repository, int id)
        {
            var results = await repository.GetById(id);
            if (results != null)
            {
                var student = new
                {
                    firstname = results.FirstName,
                    lastname = results.LastName,
                    dateofbirth = results.DateOfBirth,
                    courseid = results.CourseId,
                    averagegrade = results.AvgGrade,
                    studentcourse = results.StudentCourse
                };
                return TypedResults.Ok(student);
            }
            return TypedResults.BadRequest("Student not found");

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddStudent(IRepository<Student> studentrepo, IRepository<Course> courserepo, StudentPostModel model)
        {
            var checkStudent = await studentrepo.GetAll();
            var checkCourse = await courserepo.GetById(model.CourseId);

            if (checkStudent.Any(x => x.FirstName == model.FirstName && x.LastName == model.LastName))
            {
                return TypedResults.BadRequest("Student already exist");

            }
            if(checkCourse == null)
            {
                return TypedResults.NotFound("No course matches given id");
            }

            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                AvgGrade = model.AvgGrade,
                DateOfBirth = model.DateOfBirth,
                CourseId = model.CourseId,
                StudentCourse = checkCourse
            };

            var results = await studentrepo.Create(student);
            if (results != null) 
            {
                
                var stu = new
                {
                    firstname = results.FirstName,
                    lastname = results.LastName,
                    dateofbirth = results.DateOfBirth,
                    averagegrade = results.AvgGrade
                };
                return TypedResults.Ok(stu);
            }
            return TypedResults.BadRequest("Failed to add student");
            

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var checkstudent = await repository.GetById(id);
            if(checkstudent == null)
            {
                return TypedResults.NotFound("Student does not exist");
            }

            var deletestudent = await repository.Delete(id);
            if (deletestudent != null) 
            {
                var stu = new
                {
                    firstname = deletestudent.FirstName,
                    lastname = deletestudent.LastName,
                    dateofbirth = deletestudent.DateOfBirth,
                    courseid = deletestudent.CourseId,
                    averagegrade = deletestudent.AvgGrade
                };
                return TypedResults.Ok(stu);
            }
            return TypedResults.BadRequest("Could not find and delete student");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, StudentPutModel model)
        {
            try
            {
                var entity = await repository.GetById(id);

                if(entity != null)
                {
                    if (model.FirstName == "string") model.FirstName = string.Empty;
                    if (model.LastName == "string") model.LastName = string.Empty;
                    if (model.DateOfBirth == 0) model.DateOfBirth = null;
                    if (model.CourseId == 0) model.CourseId = null;
                    if (model.AvgGrade == 0) model.AvgGrade = null;
                    entity.FirstName = !string.IsNullOrEmpty(model.FirstName) ? model.FirstName : entity.FirstName;
                    entity.LastName = !string.IsNullOrEmpty(model.LastName) ? model.LastName : entity.LastName;
                    entity.DateOfBirth = model.DateOfBirth != null ? model.DateOfBirth.Value : entity.DateOfBirth;
                    entity.CourseId = model.CourseId != null ? model.CourseId.Value : entity.CourseId;
                    entity.AvgGrade = model.AvgGrade != null ? model.AvgGrade.Value : entity.AvgGrade;
                    var result = await repository.Update(entity);

                    var student = new
                    {
                        firstname = result.FirstName,
                        lastname = result.LastName,
                        dateofbirth = result.DateOfBirth,
                        courseid = result.CourseId,
                        averagegrade = result.AvgGrade
                    };

                    return TypedResults.Ok(student);
                }
                else return Results.NotFound("Student does not exist");
            }
            catch (Exception ex) { return TypedResults.Problem(ex.Message); }
        }


    }


}
