using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.wwwapi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentGetDTO>();
            CreateMap<StudentPostDTO, Student>();

            CreateMap<Course, CourseGetDTO>();
            CreateMap<CoursePostDTO, Course>();
        }
    }
}
