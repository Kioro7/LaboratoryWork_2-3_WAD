using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreApp.Models
{
    public partial class Statistics
    {
        [Key]
        public int Id { get; set; }
        public int GameId { get; set; }
        public string UserName { get; set; }
        public float Rating { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}
