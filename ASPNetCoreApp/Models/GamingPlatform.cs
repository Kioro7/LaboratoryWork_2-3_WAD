using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace ASPNetCoreApp.Models
{
    public partial class GamingPlatform : DbContext
    {
        //#region Constructor
        //public GamingPlatform(DbContextOptions<GamingPlatform> options) 
        //    : base(options) { }
        //#endregion

        protected readonly IConfiguration Configuration;
        public GamingPlatform(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>();
            modelBuilder.Entity<Game>().HasKey(x => x.Id);

            modelBuilder.Entity<Statistics>();
            modelBuilder.Entity<Statistics>().HasKey(x => x.Id);

            modelBuilder.Entity<Genre>();
            modelBuilder.Entity<Genre>().HasKey(x => x.Id);
        }
    }
}
