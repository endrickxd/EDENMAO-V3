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
    public class Articulo : BaseEntity
    {
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria? IdCategoriaNav { get; set; }
        [InverseProperty("IdArticuloNav")]
        public List<Articulo_Personificacion> Articulo_Personificacion { get; set; } = new List<Articulo_Personificacion>();
    }
}
