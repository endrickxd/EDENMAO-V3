using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOs.Articulo
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
        [StringLength(30)]
        public string NombreCategoria { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime FechaRegistro { get; set; }
    }
}
