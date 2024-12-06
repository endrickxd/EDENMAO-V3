using Edenmao.UI.Frontend.Prueba;
using System.Net.Http.Json;

namespace Edenmao.UI.Frontend.Services
{
	public class PersonificacionesServices
	{
			private readonly HttpClient _httpClient;
			public PersonificacionesServices(HttpClient httpClient)
			{
				_httpClient = httpClient;
			}
			public async Task<IEnumerable<Personificacionp>> GetAllPersonificacion()
			{
				return await _httpClient.GetFromJsonAsync<IEnumerable<Personificacionp>>("api/Personificacion/ObtenerPersonificaciones");
			}
			public async Task<Personificacionp> GetPersonificacionById(int id)
			{
				return await _httpClient.GetFromJsonAsync<Personificacionp>($"api/Personificacion/ObtenerPersonificacionPorID/{id}");
			}
			public async Task CreatePersonificaciones(Personificacionp personificacion)
			{
				await _httpClient.PostAsJsonAsync("api/Personificacion/CrearPersonificacion", personificacion);
			}
			public async Task UpdatePersonificaciones(int id, Personificacionp personificacion)
			{
				var response = await _httpClient.PutAsJsonAsync($"api/Personificacion/{id}", personificacion);
				if (!response.IsSuccessStatusCode)
				{
					var errorMessage = await response.Content.ReadAsStringAsync();
					throw new Exception($"Error al actualizar las Personificacion: {errorMessage}");
				}
			}
			public async Task DeletePersonificaciones(int id)
			{
				await _httpClient.DeleteAsync($"api/Personificacion/EliminarPersonificacion/{id}");
			}
		}
}
