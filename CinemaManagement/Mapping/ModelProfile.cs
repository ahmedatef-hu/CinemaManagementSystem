using AutoMapper;
using CinemaManagement.DTOs.Booking;
using CinemaManagement.DTOs.Customer;
using CinemaManagement.DTOs.Genre;
using CinemaManagement.DTOs.Movie;
using CinemaManagement.Models;

namespace CinemaManagement.Mapping
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Genre, GetGenreDTO>();
            CreateMap<CreateGenreDTO, Genre>();


            CreateMap<Movie, GetMovieDTO>();
            CreateMap<CreateMovieDTO, Movie>();


            CreateMap<Customer, GetCustomerDTO>();
            CreateMap<CreateCustomerDTO, Customer>();


            CreateMap<Booking, GetBookingDTO>();
            CreateMap<CreateBookingDTO, Booking>();
        }
    }
}
