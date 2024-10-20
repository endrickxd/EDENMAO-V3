using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOS
{
    public class ArticuloDTO
    {
        public int IdArticulo { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public int IdPersonificacion { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public string Estatus { get; set; }
    }
}
