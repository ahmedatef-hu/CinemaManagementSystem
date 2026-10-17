using CinemaManagement.Repos.Interfaces;

namespace CinemaManagement.UnitOFWork
{
    public interface IUnitOfWork
    {
        IGenreRepo genreRepo { get; }
        IMovieRepo movieRepo { get; }
        ICustomerRepo customerRepo { get; }
        IBookingRepo bookingRepo { get; }
        int Save();
    }
}
