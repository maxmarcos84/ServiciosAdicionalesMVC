using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.Repository
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<PedidoDeServicios> PedidosDeServicios { get; set;}
        public DbSet<Sector> Sector { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Sitio> Sitios { get; set; }
        public DbSet<TipoAdicional> TiposAdicional { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Necesario para que Identity configure las tablas relacionadas
            // Relación de PedidoDeServicios con Usuario como Solicitante
            modelBuilder.Entity<PedidoDeServicios>()
                .HasOne(p => p.Solicitante)
                .WithMany(u => u.PedidosComoSolicitante)
                .HasForeignKey(p => p.SolicitanteId)
                .OnDelete(DeleteBehavior.Restrict);  // Evitar la eliminación en cascada
            
            // Relación de PedidoDeServicios con Usuario como Empleado
            modelBuilder.Entity<PedidoDeServicios>()
                .HasOne(p => p.Empleado)
                .WithMany(u => u.PedidosComoEmpleado)
                .HasForeignKey(p => p.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);  // Evitar la eliminación en cascada
        }

    }
}
