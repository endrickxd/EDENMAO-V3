using Edenmao.Core.DTOs.Articulo;
using Edenmao.Core.DTOs.Categoria;
using Edenmao.UI.Frontend.Modals;
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
		public async Task<IEnumerable<Articulop>> GetAllArticulos()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Articulop>>("api/Articulo/ObtenerArticulos");
		}
		public async Task<Articulop> GetArticulosById(int id)
		{
			return await _httpClient.GetFromJsonAsync<Articulop>($"api/Articulo/ObtenerArticuloPorId/{id}");
		}
		public async Task CreateArticulos(Articulop articulo)
		{
			await _httpClient.PostAsJsonAsync("api/Articulo/CrearArticulo", articulo);
		}
		public async Task UpdateArticulos(int id, Articulop articulo)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Articulo/{id}", articulo);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar la Articulo: {errorMessage}");
			}
		}
		public async Task DeleteArticulos(int id)
		{
			await _httpClient.DeleteAsync($"api/Articulo/EliminarArticulo/{id}");
		}
	}
}
