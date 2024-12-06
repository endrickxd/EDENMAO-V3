using System.ComponentModel.DataAnnotations;

namespace Edenmao.UI.Frontend.Modals
{
	public class Clientesp
	{
		public int Id { get; set; }
		[StringLength(30)]
		public string Nombre { get; set; }
		[StringLength(30)]
		public string Apellido { get; set; }
		[StringLength(100)]
		public string Email { get; set; }
		[StringLength(100)]
		public string Direccion { get; set; }
		[StringLength(30)]
		public string Telefono { get; set; }
		public int IdUsuario { get; set; }
		public string RegistradoPor { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}
