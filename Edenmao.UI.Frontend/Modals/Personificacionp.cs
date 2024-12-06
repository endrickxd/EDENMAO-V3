using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Edenmao.UI.Frontend.Prueba
{
	public class Personificacionp
	{
		public int Id { get; set; }
		[StringLength(30)]
		public string Nombre { get; set; }
		[StringLength(50)]
		public string Descripcion { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Precio { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}
