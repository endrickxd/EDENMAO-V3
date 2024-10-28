using Edenmao.Domain.ClaseBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Rol : BaseEntity
    {
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        [InverseProperty("IdRolNav")]
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
