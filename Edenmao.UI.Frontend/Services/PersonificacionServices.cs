using Edenmao.Core.DTOs.Categoria;
using Edenmao.Core.DTOs.Personificacion;
using System.Net.Http.Json;

namespace Edenmao.UI.Frontend.Services
{
	//api/Personificaciones
	public class PersonificacionServices
	{
		private readonly HttpClient _httpClient;
		public PersonificacionServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<PersonificacionDTO>> GetAllPersonificacion()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<PersonificacionDTO>>("api/Personificaciones");
		}
		public async Task<PersonificacionDTO> GetPersonificacionById(int id)
		{
			return await _httpClient.GetFromJsonAsync<PersonificacionDTO>($"api/Personificaciones/{id}");
		}
		public async Task CreatePersonificaciones(PersonificacionDTO personificacion)
		{
			await _httpClient.PostAsJsonAsync("api/Personificaciones", personificacion);
		}
		public async Task UpdateCategorias(int id, PersonificacionDTO personificacion)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Personificaciones/{id}", personificacion);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar las Personificaciones: {errorMessage}");
			}
		}
		public async Task DeleteCategorias(int id)
		{
			await _httpClient.DeleteAsync($"api/Personificaciones/{id}");
		}
	}
}
