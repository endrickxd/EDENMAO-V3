using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOS
{
    public class PersonificacionDTO
    {
        public int IdPersonificacion { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
