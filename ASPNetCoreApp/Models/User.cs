using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
namespace ASPNetCoreApp.Models
{
    public partial class User : IdentityUser<int>
    {
        public User() 
        { 
            BuyingGames = new HashSet<BuyingGame>();
        }

        [StringLength(50)]
        public string? Nickname { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
        public virtual ICollection<BuyingGame> BuyingGames { get; set;}
    }
}