using api_cinema_challenge.DTO;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using api_cinema_challenge.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Endpoints
{
    public static class ScreeningEndpoints
    {
        public static void ConfigureScreeningEndpoints(this WebApplication app)
        {
            var ScreeningGroup = app.MapGroup("/movies");

            ScreeningGroup.MapGet("/{MovieId}/screenings", GetScreenings);
            ScreeningGroup.MapPost("/{MovieId}/screenings", AddScreening);

        }
        
        public static async Task<IResult> GetScreenings(IRepository<Screening> screenRepo, IRepository<Movie> movieRepo, int movieId, IMapper mapper)

        {

            Movie movie = await movieRepo.GetById(movieId);
            Console.WriteLine("number: ", movie.Screenings.Count);

            if (movie == null) return Results.NotFound();
            List<Screening> screen = await screenRepo.GetQuery().Where(s => s.MovieId == movieId).ToListAsync();


            return Results.Ok(new Response<List<ScreeningDTO>>("Success", mapper.Map<List<ScreeningDTO>>(screen)));

        }

        public static async Task<IResult> AddScreening(IRepository<Screening> screenRepo, IRepository<Movie> movieRepo, ScreeningPost screening, IMapper mapper, int movieId)
        {
            Movie movie = await movieRepo.GetById(movieId);

            if (movie == null) return Results.NotFound();

            Screening newScreening = new Screening
            {
                MovieId = movie.Id,
                ScreenNumber = screening.ScreenNumber,
                Capacity = screening.Capacity,
                StartsAt = screening.StartsAt,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var result = await screenRepo.Add(newScreening);

            return Results.Ok(new Response<ScreeningDTO>("Success", mapper.Map<ScreeningDTO>(result)));
        }

    }
}
