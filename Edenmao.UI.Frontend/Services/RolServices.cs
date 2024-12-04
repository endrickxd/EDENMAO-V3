using Edenmao.UI.Frontend.Modals;
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
		public async Task<IEnumerable<Rolp>> GetAllRols()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Rolp>>("api/Rol/ObtenerRol");
		}
		public async Task<Rolp> GetRolsById(int id)
		{
			return await _httpClient.GetFromJsonAsync<Rolp>($"api/Rol/ObtenerRolPorID/{id}");
		}
		public async Task CreateRols(Rolp Rol)
		{
			await _httpClient.PostAsJsonAsync("api/Roles/CrearRol", Rol);
		}
		public async Task UpdateRols(int id, Rolp Rol)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Rol/{id}", Rol);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar las Roles: {errorMessage}");
			}
		}
		public async Task DeleteRols(int id)
		{
			await _httpClient.DeleteAsync($"api/Rol/EliminarRol/{id}");
		}
	}
}