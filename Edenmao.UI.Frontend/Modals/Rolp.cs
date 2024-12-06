using System.ComponentModel.DataAnnotations;

namespace Edenmao.UI.Frontend.Modals
{
	public class Rolp
	{
		public int Id { get; set; }
		[StringLength(30)]
		public string Nombre { get; set; }
		[StringLength(50)]
		public string Descripcion { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}
