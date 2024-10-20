using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [StringLength(30)]
        public string Username { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        public string Estatus { get; set; }
        [ForeignKey("IdRol")]
        public Rol? IdRolNav { get; set; }
        [InverseProperty("IDUsuarioNav")]
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
