using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOs.Cliente
{
    public class ClienteResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }
        [StringLength(30)]
        public string Telefono { get; set; }
        public int IdUsuario { get; set; }
    }
}
