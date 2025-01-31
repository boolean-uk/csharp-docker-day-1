using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IMovieRepository
    {

        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(int movieId, Movie movie);
        Task<Movie> DeleteMovie(int movieId);


        Task<IEnumerable<Screening>> GetScreeningsByMovieId(int movieId);
        Task<Screening> CreateScreenings(Screening screening);


    }
}