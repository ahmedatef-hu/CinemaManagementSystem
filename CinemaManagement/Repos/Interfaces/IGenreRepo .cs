using CinemaManagement.Models;

namespace CinemaManagement.Repos.Interfaces
{
    public interface IGenreRepo : IGenericRepo<Genre>
    {
        Task<List<Genre>> GetGenresWithMovies();
    }
}
