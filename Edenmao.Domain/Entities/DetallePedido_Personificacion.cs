using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class DetallePedido_Personificacion
    {
        [Key]
        public int Id { get; set; }
        public int IdDetallePedido { get; set; }
        [ForeignKey("IdDetallePedido")]
        public DetallePedido? IdDetallePedidoNav { get; set; }
        public int IdPersonificacion { get; set; }
        [ForeignKey("IdPersonificacion")]
        public Personificacion? IdPersonificacionNav { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
    }
}
