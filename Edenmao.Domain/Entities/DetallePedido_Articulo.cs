using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class DetallePedido_Articulo
    {
        [Key]
        public int IdDetalleArticulo { get; set; }
        public int IdPedido { get; set; }
        public int IdArticulo { get; set; }
        [ForeignKey("IdPedido")]
        public Pedido? IdPedidoNav { get; set; }
        [ForeignKey("IdArticulo")]
        public Articulo? IdArticuloNav { get; set; }
    }
}
