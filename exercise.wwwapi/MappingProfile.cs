using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects.Courses;
using exercise.wwwapi.DataTransferObjects.Students;

namespace exercise.wwwapi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Course
            CreateMap<AddCourseDTO, Course>();
            CreateMap<Course, GetCourseDTO>();

            // Student
            CreateMap<AddStudentDTO, Student>();
            CreateMap<Student, GetStudentDTO>();
        }
    }
}
