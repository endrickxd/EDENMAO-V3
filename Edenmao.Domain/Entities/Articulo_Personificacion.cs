using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Articulo_Personificacion
    {
        [Key]
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        [ForeignKey("IdArticulo")]
        public Articulo? IdArticuloNav { get; set; }
        public int IdPersonificacion { get; set; }
        [ForeignKey("IdPersonificacion")]
        public Personificacion? IdPersonificacionNav { get; set; }
    }
}
