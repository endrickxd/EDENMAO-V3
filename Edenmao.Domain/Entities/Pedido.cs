using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalDescuento { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalItbis { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }
        public DateTime FechaEmisión { get; set; }
        public string Estatus { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente? IdClienteNav { get; set; }
        [InverseProperty("IDPedidoNav")]
        public virtual List<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
    }
}
