using Edenmao.Core.DTOs.Articulo;
using System.Net.Http.Json;

namespace Edenmao.UI.Frontend.Services
{
	public class ArticuloServices
	{
		private readonly HttpClient _httpClient;
		public ArticuloServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<ArticuloDTO>> GetAllArticulos()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<ArticuloDTO>>("api/Articulos");
		}
		public async Task<ArticuloDTO> GetArticulosById(int id)
		{
			return await _httpClient.GetFromJsonAsync<ArticuloDTO>($"api/Articulos/{id}");
		}
		public async Task CreateArticulos(ArticuloDTO articulo)
		{
			await _httpClient.PostAsJsonAsync("api/Articulos", articulo);
		}
		public async Task UpdateArticulos(int id, ArticuloDTO articulo)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Articulos/{id}", articulo);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar la Articulo: {errorMessage}");
			}
		}
		public async Task DeleteArticulos(int id)
		{
			await _httpClient.DeleteAsync($"api/Articulos/{id}");
		}
	}
}
