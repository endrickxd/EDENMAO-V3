using Edenmao.Domain.ClaseBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public int IdUsuario { get; set; }
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
        [ForeignKey("IdUsuario")]
        public virtual Usuario? IdUsuarioNav { get; set; }
        [InverseProperty("IdClienteNav")]
        public virtual List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
