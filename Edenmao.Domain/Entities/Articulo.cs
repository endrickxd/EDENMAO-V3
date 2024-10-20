using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Articulo
    {
        [Key]
        public int IdArticulo { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
        public int IdPersonificacion { get; set; }
        public string Estatus { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria? IdCategoriaNav { get; set; }
        [ForeignKey("IdPersonificacion")]
        public Personificacion? IdPersonificacionNav { get; set; }
        [InverseProperty("IdArticuloNav")]
        public List<DetallePedido_Articulo> DetallePedido_Articulo { get; set; } = new List<DetallePedido_Articulo>();
    }
}
