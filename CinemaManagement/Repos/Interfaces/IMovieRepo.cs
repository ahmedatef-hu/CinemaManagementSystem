using CinemaManagement.Models;

namespace CinemaManagement.Repos.Interfaces
{
    public interface IMovieRepo : IGenericRepo<Movie>
    {
        Task<List<Movie>> search(string Name);
        Task<List<Movie>> RatingGreater(int Rating);
        Task<List<Movie>> GetPriceBetween(decimal min, decimal max);
        Task<List<Movie>> GetAvailableMovies();
        Task<List<Movie>> GetTopRated();
        Task<Movie?> GetLatestMovie();
        Task<Movie?> GetMostBooked();
        Task<int> GetMoviesCount();
        Task<decimal> GetAveragePrice();
        Task<List<Movie>> GetMoviesWithGenre();
        Task<List<Movie>> GetPagedMovies(int pageNumber, int pageSize);
    }
}
