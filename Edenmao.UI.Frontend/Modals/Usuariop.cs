using System.ComponentModel.DataAnnotations;

namespace Edenmao.UI.Frontend.Modals
{
	public class Usuariop
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
		[StringLength(30)]
		public string Username { get; set; }
		[StringLength(255)]
		public string Password { get; set; }
		public int IdRol { get; set; }
		public string NombreRol { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime FechaRegistro { get; set; }
	}
}
