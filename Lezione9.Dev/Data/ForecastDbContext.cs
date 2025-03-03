using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Lezione9.Dev.Data
{
    public class
        ForecastDbContext : DbContext
    {
        public ForecastDbContext() : base() { }

        public ForecastDbContext(DbContextOptions<ForecastDbContext> options)
            : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Favcity> Favcities { get; set; }

        public DbSet<Giorno> Previsioni { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(e => e.Email)
            .IsUnique();
        }
        public DbSet<GiornoGiornaliera> PrevisioneGiornalieras{get;set;}

    
    }
}
