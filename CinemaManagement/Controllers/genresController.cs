using AutoMapper;
using CinemaManagement.DTOs.Genre;
using CinemaManagement.Models;
using CinemaManagement.UnitOFWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class genresController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public genresController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await unitOfWork.genreRepo.GetAll();
            var genresdto = mapper.Map<List<GetGenreDTO>>(genres);
            return Ok(genresdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genre = await unitOfWork.genreRepo.GetById(id);
            var genredto = mapper.Map<GetGenreDTO>(genre);
            return Ok(genredto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateGenreDTO dto)
        {
            var genre = mapper.Map<Genre>(dto);
            await unitOfWork.genreRepo.Create(genre);
            unitOfWork.Save();
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateGenreDTO dto)
        {
            var genre = await unitOfWork.genreRepo.GetById(id);
            mapper.Map(dto, genre);

            unitOfWork.genreRepo.Update(genre);
            unitOfWork.Save();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await unitOfWork.genreRepo.GetById(id);
            await unitOfWork.genreRepo.Delete(genre);
            unitOfWork.Save();
            return NoContent();
        }
        [HttpGet("movies")]
        public async Task<IActionResult> GetWithMovies()
        {
            var genres = await unitOfWork.genreRepo.GetGenresWithMovies();
            var genresdto = mapper.Map<List<GetGenreDTO>>(genres);
            return Ok(genresdto);
        }
    }
}
