using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
