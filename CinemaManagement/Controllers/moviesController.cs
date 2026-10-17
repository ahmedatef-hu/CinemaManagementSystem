using AutoMapper;
using CinemaManagement.DTOs.Genre;
using CinemaManagement.DTOs.Movie;
using CinemaManagement.Models;
using CinemaManagement.UnitOFWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moviesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public moviesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await unitOfWork.movieRepo.GetAll();
            var moviesdto = mapper.Map<List<GetMovieDTO>>(movies);
            return Ok(moviesdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await unitOfWork.movieRepo.GetById(id);
            var moviedto = mapper.Map<GetMovieDTO>(movie);
            moviedto.GenreName = movie.Genre.Name;
            return Ok(moviedto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieDTO dto)
        {
            var movie = mapper.Map<Movie>(dto);
            await unitOfWork.movieRepo.Create(movie);
            unitOfWork.Save();
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateMovieDTO dto)
        {
            var movie = await unitOfWork.movieRepo.GetById(id);
            mapper.Map(dto, movie);

            unitOfWork.movieRepo.Update(movie);
            unitOfWork.Save();
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string Title)
        {
            var movies = await unitOfWork.movieRepo.search(Title);
            var moviesdto = mapper.Map<List<Movie>>(movies);
            return Ok(moviesdto);
        }

        [HttpGet("rating-greater-than/{rating}")]
        public async Task<IActionResult> RatingGreater(int rating)
        {
            var movies = await unitOfWork.movieRepo.RatingGreater(rating);
            var moviesdto = mapper.Map<List<Movie>>(movies);
            return Ok(moviesdto);
        }
        [HttpGet("price-between")]
        public async Task<IActionResult> GetPriceBetween(decimal min, decimal max)
        {
            var movies = await unitOfWork.movieRepo.GetPriceBetween(min, max);

            var result = mapper.Map<List<GetMovieDTO>>(movies);

            return Ok(result);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableMovies()
        {
            var movies = await unitOfWork.movieRepo.GetAvailableMovies();

            var result = mapper.Map<List<GetMovieDTO>>(movies);

            return Ok(result);
        }

        [HttpGet("top-rated")]
        public async Task<IActionResult> GetTopRated()
        {
            var movies = await unitOfWork.movieRepo.GetTopRated();

            var result = mapper.Map<List<GetMovieDTO>>(movies);

            return Ok(result);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestMovie()
        {
            var movie = await unitOfWork.movieRepo.GetLatestMovie();

            if (movie == null)
                return NotFound();

            var result = mapper.Map<GetMovieDTO>(movie);

            return Ok(result);
        }

        [HttpGet("most-booked")]
        public async Task<IActionResult> GetMostBooked()
        {
            var movie = await unitOfWork.movieRepo.GetMostBooked();

            if (movie == null)
                return NotFound();

            var result = mapper.Map<GetMovieDTO>(movie);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetMoviesCount()
        {
            var count = await unitOfWork.movieRepo.GetMoviesCount();

            return Ok(count);
        }

        [HttpGet("average-price")]
        public async Task<IActionResult> GetAveragePrice()
        {
            var average = await unitOfWork.movieRepo.GetAveragePrice();

            return Ok(average);
        }

        [HttpGet("genre-details")]
        public async Task<IActionResult> GetMoviesWithGenre()
        {
            var movies = await unitOfWork.movieRepo.GetMoviesWithGenre();

            var result = mapper.Map<List<GetMovieDTO>>(movies);

            return Ok(result);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedMovies(int pageNumber = 1, int pageSize = 5)
        {
            var movies = await unitOfWork.movieRepo.GetPagedMovies(pageNumber, pageSize);

            var result = mapper.Map<List<GetMovieDTO>>(movies);

            return Ok(result);
        }
    }
}
