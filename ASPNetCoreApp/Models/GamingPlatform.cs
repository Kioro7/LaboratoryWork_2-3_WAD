using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace ASPNetCoreApp.Models
{
    public partial class GamingPlatform : DbContext
    {
        #region Constructor
        public GamingPlatform(DbContextOptions<GamingPlatform> options) 
            : base(options) { }
        #endregion

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
