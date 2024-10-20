using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOS
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public DateTime FechaRegistro { get; set; }
        public string Estatus { get; set; }
        
    }
}
