using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TipoAdicional> TiposAdicional { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Sitio> Sitios { get; set; }
        public DbSet<Sector> Sector { get; set; }

    }
}
