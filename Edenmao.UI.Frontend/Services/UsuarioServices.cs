using Edenmao.Core.DTOs.Rol;
using Edenmao.Core.DTOs.Usuario;
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
		public async Task<IEnumerable<UsuarioDTO>> GetAllUsuario()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioDTO>>("api/Usuarios");
		}
		public async Task<UsuarioDTO> GetUsuarioById(int id)
		{
			return await _httpClient.GetFromJsonAsync<UsuarioDTO>($"api/Usuarios/{id}");
		}
		public async Task CreateUsuarioes(UsuarioDTO Usuario)
		{
			await _httpClient.PostAsJsonAsync("api/Usuarios", Usuario);
		}
		public async Task<IEnumerable<RolDTO>> GetAllRol()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<RolDTO>>("api/Roles");
		}
		public async Task UpdateCategorias(int id, UsuarioDTO Usuario)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Usuarios/{id}", Usuario);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar las Usuarios: {errorMessage}");
			}
		}
		public async Task DeleteCategorias(int id)
		{
			await _httpClient.DeleteAsync($"api/Usuarios/{id}");
		}
	}
}
