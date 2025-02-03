using api_cinema_challenge.DTO;
using api_cinema_challenge.Models;
using AutoMapper;

namespace api_cinema_challenge.Tools
{
    public class Mapper : Profile
    {

        public Mapper()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Screening, ScreeningDTO>();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.ScreenNumber, opt => opt.MapFrom(src => src.ScreenNumber))
            //.ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
            //.ForMember(dest => dest.StartsAt, opt => opt.MapFrom(src => src.StartsAt))
            //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            //.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
            CreateMap<Ticket, TicketDTO>();
        }
    }
}
