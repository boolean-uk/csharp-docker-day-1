using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;

namespace exercise.wwwapi.Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>();

            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
        }
    }
}
