using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreApp.Models
{
    public class Genre
    {
        public Genre()
        {
            Game = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Game> Game { get; set; }
    }
}
