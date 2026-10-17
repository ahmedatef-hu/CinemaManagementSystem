using CinemaManagement.Data;
using CinemaManagement.Models;
using CinemaManagement.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Repos.Implementations
{
    public class MovieRepo : GenericRepo<Movie>, IMovieRepo
    {
        public MovieRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Movie>> GetAvailableMovies()
        {
            return await context.Movies.Where(c => c.AvailableSeats > 0).ToListAsync();
        }

        public async Task<decimal> GetAveragePrice()
        {
            return await context.Movies.AverageAsync(c => c.TicketPrice);
        }

        public async Task<Movie?> GetLatestMovie()
        {
            return await context.Movies.OrderByDescending(c => c.ReleaseYear)
                .FirstOrDefaultAsync();
        }

        public async Task<Movie?> GetMostBooked()
        {
            return await context.Movies
                .OrderByDescending(c => c.Bookings.Count())
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetMoviesCount()
        {
            return await context.Movies.CountAsync();
        }

        public async Task<List<Movie>> GetMoviesWithGenre()
        {
            return await context.Movies
                .Include(c => c.Genre)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetPagedMovies(int pageNumber, int pageSize)
        {
            return await context.Movies
            .OrderBy(m => m.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }

        public async Task<List<Movie>> GetPriceBetween(decimal min, decimal max)
        {
            return await context.Movies.Where(c => c.TicketPrice >= min && c.TicketPrice <= max).ToListAsync();
        }

        public async Task<List<Movie>> GetTopRated()
        {
            return await context.Movies
            .OrderByDescending(m => m.Rating)
            .Take(5)
            .ToListAsync();
        }

        public async Task<List<Movie>> RatingGreater(int Rating)
        {
            return await context.Movies.Where(c => c.Rating > Rating)
                .OrderByDescending(c => c.Rating).ToListAsync();
        }

        public async Task<List<Movie>> search(string Name)
        {
            return await context.Movies.Where(c => c.Title.Contains(Name)).ToListAsync();
        }
    }
}
