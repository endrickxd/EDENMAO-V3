using Microsoft.EntityFrameworkCore;
using Edenmao.Domain.Entities;

namespace Edenmao.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Articulo_Personificacion> Articulos_Personificaciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<DetallePedido_Personificacion> DetallePedidos_Personificaciones { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Personificacion> Personificaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Server=ORLANDOABREU\\SQLEXPRESS;Database=SurPrintDB;integrated security=true; TrustServerCertificate=True");
        
    }

}
