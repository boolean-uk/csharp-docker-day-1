using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects.CourseDTOs;
using exercise.wwwapi.DataTransferObjects.StudentDTOs;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<GetCourseDTO> CreateCourse(CreateCourseDTO cDTO)
        {
            Course c = new()
            {
                StartedAt = cDTO.StartedAt,
                Title = cDTO.Title,
            };
            _db.Courses.Add(c);
            await _db.SaveChangesAsync();
            return new GetCourseDTO()
            {
                Id = c.Id,
                StartedAt = c.StartedAt,
                Title = c.Title,
                Students = []
            };
        }


        public async Task<IEnumerable<GetCourseDTO>> GetCourses()
        {
            return await _db.Courses.Select(x => new GetCourseDTO()
            {
                Id = x.Id,
                StartedAt = x.StartedAt,
                Title = x.Title,
                Students = x.Students.Select(y => new CourseStudentDTO()
                {
                    Id = y.Id,
                    DateOfBirth = y.DateOfBirth,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    AvgGrade = y.AvgGrade,
                }).ToList()
            }).ToListAsync();
        }
        public async Task<GetCourseDTO?> GetCourseById(int id)
        {
            return await _db.Courses.Where(x => x.Id == id).Select(x => new GetCourseDTO()
            {
                Id = x.Id,
                StartedAt = x.StartedAt,
                Title = x.Title,
                Students = x.Students.Select(y => new CourseStudentDTO()
                {
                    Id = y.Id,
                    DateOfBirth = y.DateOfBirth,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    AvgGrade = y.AvgGrade,
                }).ToList()
            }).FirstOrDefaultAsync();
        }
        public async Task<GetCourseDTO?> UpdateCourse(int courseId, UpdateCourseDTO uDTO)
        {
            Course? dbCourse = await _db.Courses.Where(x => x.Id == courseId).Include(y => y.Students).FirstOrDefaultAsync();
            if (dbCourse == null) return null;
            dbCourse.Title = uDTO.Title ?? dbCourse.Title;
            dbCourse.StartedAt = uDTO.StartedAt ?? dbCourse.StartedAt;
            await _db.SaveChangesAsync();
            return new GetCourseDTO()
            {
                Id = dbCourse.Id,
                StartedAt = dbCourse.StartedAt,
                Title = dbCourse.Title,
                Students = dbCourse.Students.Select(y => new CourseStudentDTO()
                {
                    Id = y.Id,
                    DateOfBirth = y.DateOfBirth,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    AvgGrade = y.AvgGrade,
                }).ToList()
            };
        }

        public async Task<GetCourseDTO?> DeleteCourse(int courseId)
        {
            Course? dbCourse = await _db.Courses.Where(x => x.Id == courseId).Include(y => y.Students).FirstOrDefaultAsync();
            if (dbCourse == null) return null;
            _db.Courses.Remove(dbCourse);
            await _db.SaveChangesAsync();
            return new GetCourseDTO()
            {
                Id = dbCourse.Id,
                StartedAt = dbCourse.StartedAt,
                Title = dbCourse.Title,
                Students = dbCourse.Students.Select(y => new CourseStudentDTO()
                {
                    Id = y.Id,
                    DateOfBirth = y.DateOfBirth,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    AvgGrade = y.AvgGrade,
                }).ToList()
            };
        }

        public async Task<GetStudentDTO?> CreateStudent(CreateStudentDTO cDTO)
        {
            Course? c = await _db.Courses.Where(x => x.Id == cDTO.CourseId).FirstOrDefaultAsync();
            if (c == null) { return null; }
            Student s = new()
            {
                FirstName = cDTO.FirstName,
                LastName = cDTO.LastName,
                DateOfBirth = cDTO.DateOfBirth,
                CourseId = cDTO.CourseId,
                AvgGrade = cDTO.AvgGrade,
            };
            _db.Students.Add(s);
            await _db.SaveChangesAsync();
            return new GetStudentDTO()
            {
                Id = s.Id,
                AvgGrade = s.AvgGrade,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth,
                Course = new()
                {
                    Id = c.Id,
                    StartedAt = c.StartedAt,
                    Title = c.Title,
                }
            };
        }

        public async Task<IEnumerable<GetStudentDTO>> GetStudents()
        {
            return await _db.Students.Select(x => new GetStudentDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Course = new StudentCourseDTO()
                {
                    Id = x.Course.Id,
                    StartedAt = x.Course.StartedAt,
                    Title = x.Course.Title,
                },
                AvgGrade = x.AvgGrade
            }).ToListAsync();
        }

        public async Task<GetStudentDTO?> GetStudentById(int id)
        {
            return await _db.Students.Where(x => x.Id == id).Select(x => new GetStudentDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Course = new StudentCourseDTO()
                {
                    Id = x.Course.Id,
                    StartedAt = x.Course.StartedAt,
                    Title = x.Course.Title,
                },
                AvgGrade = x.AvgGrade
            }).FirstOrDefaultAsync();
        }
        public async Task<GetStudentDTO?> UpdateStudent(int studentId, UpdateStudentDTO uDTO)
        {
            Student? dbStudent = await _db.Students.Where(x => x.Id == studentId).Include(y => y.Course).FirstOrDefaultAsync();
            if (dbStudent == null) { return null; }
            dbStudent.FirstName = uDTO.FirstName ?? dbStudent.FirstName;
            dbStudent.LastName = uDTO.LastName ?? dbStudent.LastName;
            dbStudent.DateOfBirth = uDTO.DateOfBirth ?? dbStudent.DateOfBirth;
            dbStudent.AvgGrade = uDTO.AvgGrade ?? dbStudent.AvgGrade;
            dbStudent.CourseId = uDTO.CourseId ?? dbStudent.CourseId;
            return new GetStudentDTO()
            {
                Id = dbStudent.Id,
                AvgGrade = dbStudent.AvgGrade,
                FirstName = dbStudent.FirstName,
                LastName = dbStudent.LastName,
                DateOfBirth = dbStudent.DateOfBirth,
                Course = new()
                {
                    Id = dbStudent.Course.Id,
                    StartedAt = dbStudent.Course.StartedAt,
                    Title = dbStudent.Course.Title,
                }
            };
        }

        public async Task<GetStudentDTO?> DeleteStudent(int studentId)
        {
            Student? dbStudent = await _db.Students.Where(x => x.Id == studentId).Include(y => y.Course).FirstOrDefaultAsync();
            if (dbStudent == null) { return null; }
            _db.Students.Remove(dbStudent);
            await _db.SaveChangesAsync();
            return new GetStudentDTO()
            {
                Id = dbStudent.Id,
                AvgGrade = dbStudent.AvgGrade,
                FirstName = dbStudent.FirstName,
                LastName = dbStudent.LastName,
                DateOfBirth = dbStudent.DateOfBirth,
                Course = new()
                {
                    Id = dbStudent.Course.Id,
                    StartedAt = dbStudent.Course.StartedAt,
                    Title = dbStudent.Course.Title,
                }
            };
        }
    }
}
