using Edenmao.Core.DTOs.Rol;
using System.Net.Http.Json;

namespace Edenmao.UI.Frontend.Services
{
	public class RolServices
	{
		private readonly HttpClient _httpClient;
		public RolServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<RolDTO>> GetAllRols()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<RolDTO>>("api/Roles");
		}
		public async Task<RolDTO> GetRolsById(int id)
		{
			return await _httpClient.GetFromJsonAsync<RolDTO>($"api/Roles/{id}");
		}
		public async Task CreateRols(RolDTO Rol)
		{
			await _httpClient.PostAsJsonAsync("api/Roles", Rol);
		}
		public async Task UpdateRols(int id, RolDTO Rol)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Roles/{id}", Rol);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar las Roles: {errorMessage}");
			}
		}
		public async Task DeleteRols(int id)
		{
			await _httpClient.DeleteAsync($"api/Roles/{id}");
		}
	}
}
