using Campeonato.Entities;
using Microsoft.EntityFrameworkCore;

namespace Campeonato.Persistence
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipo>().Property(x => x.Name).HasMaxLength(20);  //tamaño de caracteres 
        }
        public DbSet<Equipo> Equipos { get; set; }
    }
}
  