using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreApp.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public string Mode { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Developer { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? ImageLink { get; set; }
        public string? Description { get; set; }
        public float Rating { get; set; }
        public int NumberRatings { get; set; }
    }
}
