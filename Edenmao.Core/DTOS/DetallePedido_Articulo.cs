using Edenmao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOS
{
    public class DetallePedido_ArticuloDTO
    {
        public int IdDetalleArticulo { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public int IdPedido { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public int IdArticulo { get; set; }
    }
}
