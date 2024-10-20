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
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<DetallePedido_Articulo> DetallePedidos_Articulos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Personificacion> Personificaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Server=ACERN5-MASUEL\\Masuel;Database=SurPrint;integrated security=true; TrustServerCertificate=True");
    }
}
