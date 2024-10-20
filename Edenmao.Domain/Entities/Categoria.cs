using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [InverseProperty("IdCategoriaNav")]
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
