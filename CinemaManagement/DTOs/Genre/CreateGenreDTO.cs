using CinemaManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.DTOs.Genre
{
    public class CreateGenreDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
