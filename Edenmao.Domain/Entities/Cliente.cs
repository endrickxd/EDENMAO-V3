using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estatus { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? IdUsuarioNav { get; set; }
        [InverseProperty("IdClienteNav")]
        public virtual List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
