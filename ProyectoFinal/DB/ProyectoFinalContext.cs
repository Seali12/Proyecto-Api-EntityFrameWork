using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DB
{
    public class ProyectoFinalContext : DbContext
    {
        public ProyectoFinalContext(DbContextOptions<ProyectoFinalContext> options) : base(options)
        {
    
        }
            public DbSet<Soldado> Soldados { get; set; }

            public DbSet<Licencia> Licencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soldado>().ToTable("Soldado");
            modelBuilder.Entity<Licencia>().ToTable("Licencias");
        }
    }
}
