using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOs.Rol
{
    public class CURol
    {
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
