using System.Security.Cryptography.X509Certificates;
using api_cinema_challenge.DTO;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using api_cinema_challenge.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Endpoints
{
    public static class MovieEndpoints
    {
        public static void ConfigureMovieEndpoints(this WebApplication app)
        {
            var movieGroup = app.MapGroup("/movies");

            movieGroup.MapGet("/", GetMovies);
            movieGroup.MapPost("/", AddMovie);
            movieGroup.MapPut("/{id}", UpdateMovie);
            movieGroup.MapDelete("/{id}", DeleteMovie);
        }

        public static async Task<IResult> GetMovies(IRepository<Movie> repo, IMapper mapper)
        {
            var movies = await repo.Get();

            return Results.Ok(new Response<List<MovieDTO>>("Success", mapper.Map<List<MovieDTO>>(movies)));
        }

        public static async Task<IResult> AddMovie(IRepository<Movie> repo, MoviePost movie, IMapper mapper)
        {
            Movie newMovie = new Movie
            {
                Title = movie.Title,
                Rating = movie.Rating,
                Description = movie.Description,
                RuntimeMins = movie.RuntimeMins,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var result = await repo.Add(newMovie);
            return Results.Ok(new Response<MovieDTO>("Success", mapper.Map<MovieDTO>(result)));
        }

        public static async Task<IResult> UpdateMovie(IRepository<Movie> repo, int id, MoviePost movie, IMapper mapper)
        {
            Movie existingMovie = await repo.GetById(id);
            if (existingMovie == null)
            {
                return Results.NotFound();
            }
            existingMovie.Title = movie.Title;
            existingMovie.Rating = movie.Rating;
            existingMovie.Description = movie.Description;
            existingMovie.RuntimeMins = movie.RuntimeMins;
            existingMovie.UpdatedAt = DateTime.Now;
            var result = await repo.Update(existingMovie);
            return Results.Ok(new Response<MovieDTO>("Success", mapper.Map<MovieDTO>(result)));
        }

        public static async Task<IResult> DeleteMovie(IRepository<Movie> repo, int id, IMapper mapper)
        {
            var existingMovie = repo.GetById(id);
            if (existingMovie == null)
            {
                return Results.NotFound();
            }
            var result = await repo.Delete(id);
            return Results.Ok(new Response<MovieDTO>("Success", mapper.Map<MovieDTO>(result)));
        }

    }
}
