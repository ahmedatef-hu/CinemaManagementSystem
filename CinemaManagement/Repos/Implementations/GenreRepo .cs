using CinemaManagement.Data;
using CinemaManagement.Models;
using CinemaManagement.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Repos.Implementations
{
    public class GenreRepo : GenericRepo<Genre>, IGenreRepo
    {
        public GenreRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Genre>> GetGenresWithMovies()
        {
            return await context.Genres
                .Include(c => c.Movies)
                .ToListAsync();
        }
    }
}
