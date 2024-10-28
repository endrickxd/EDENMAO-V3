using Edenmao.Domain.ClaseBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public int IdRol { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }
        [StringLength(30)]
        public string Telefono { get; set; }
        [StringLength(30)]
        public string Username { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [ForeignKey("IdRol")]
        public Rol? IdRolNav { get; set; }
        [InverseProperty("IdUsuarioNav")]
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        [InverseProperty("IdUsuarioNav")]
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
