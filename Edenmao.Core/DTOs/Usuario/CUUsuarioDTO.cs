using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOs.Usuario
{
    public class CUUsuarioDTO
    {
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }
        [StringLength(30)]
        public string Telefono { get; set; }
        [StringLength(30)]
        public string Username { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}
