using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOS
{
    public class DetallePedidoDTO
    {
        public int IdDetallePedido { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public int IdPedido { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Itbis { get; set; }
    }
}
