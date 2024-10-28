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
    public class Personificacion : BaseEntity
    {
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
        [InverseProperty("IdPersonificacionNav")]
        public List<Articulo_Personificacion> Articulo_Personificacion { get; set; } = new List<Articulo_Personificacion>();
    }
}
