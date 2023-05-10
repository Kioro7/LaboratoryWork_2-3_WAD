using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace ASPNetCoreApp.Models
{
    public partial class GamingPlatform : IdentityDbContext<User,IdentityRole<int>,int>
    {
        protected readonly IConfiguration Configuration;
        public GamingPlatform(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            options.UseSqlServer(Configuration.GetConnectionString("NewDB"));
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BuyingGame> BuyingGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>();
            modelBuilder.Entity<Game>().HasKey(x => x.Id);

            modelBuilder.Entity<Statistics>();
            modelBuilder.Entity<Statistics>().HasKey(x => x.Id);

            modelBuilder.Entity<Genre>();
            modelBuilder.Entity<Genre>().HasKey(x => x.Id);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BuyingGame>();
            modelBuilder.Entity<BuyingGame>().HasKey(x => x.Id);
        }
    }
}
