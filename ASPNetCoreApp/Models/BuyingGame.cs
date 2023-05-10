using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCoreApp.Models
{
    public partial class BuyingGame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
