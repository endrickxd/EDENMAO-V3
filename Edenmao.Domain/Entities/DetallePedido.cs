using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class DetallePedido
    {
        [Key]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public Pedido? IdPedidoNav { get; set; }
        public int IdArticulo { get; set; }
        [ForeignKey("IdArticulo")]
        public Articulo? IdArticuloNav { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        [InverseProperty("IdDetallePedidoNav")]
        public List<DetallePedido_Personificacion> DetallePedido_Personificacion { get; set; } = new List<DetallePedido_Personificacion>();
    }
}
