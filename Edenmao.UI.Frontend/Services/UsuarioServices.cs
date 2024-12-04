using Edenmao.UI.Frontend.Modals;
using System.Net.Http.Json;

namespace Edenmao.UI.Frontend.Services
{
	public class UsuarioServices
	{
		private readonly HttpClient _httpClient;
		public UsuarioServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<Usuariop>> GetAllUsuario()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Usuariop>>("api/Usuario/ObtenerUsuarios");
		}
		public async Task<Usuariop> GetUsuarioById(int id)
		{
			return await _httpClient.GetFromJsonAsync<Usuariop>($"api/Usuario/ObtenerUsuarioPorID/{id}");
		}
		public async Task CreateUsuarios(Usuariop Usuario)
		{
			await _httpClient.PostAsJsonAsync("api/Usuarios/CrearUsuario", Usuario);
		}
		
		public async Task UpdateUsuarios(int id, Usuariop Usuario)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Usuarios/{id}", Usuario);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar las Usuarios: {errorMessage}");
			}
		}
		public async Task DeleteUsuarios(int id)
		{
			await _httpClient.DeleteAsync($"api/Usuarios/EliminarUsuario/{id}");
		}
	}
}
