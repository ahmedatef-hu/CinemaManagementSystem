using CinemaManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.DTOs.Genre
{
    public class GetGenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Models.Movie> Movies { get; set; } = new List<Models.Movie>();

    }
}
