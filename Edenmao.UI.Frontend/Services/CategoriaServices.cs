using Edenmao.UI.Frontend.Modals;
using System.Net.Http.Json;

namespace Edenmao.UI.Frontend.Services
{
	//api/Categorias
	public class CategoriaServices
	{
		private readonly HttpClient _httpClient;
		public CategoriaServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<Categoriap>> GetAllCategorias()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Categoriap>>("api/Categoria/ObtenerCategorias");
		}
		public async Task<Categoriap> GetCategoriasById(int id)
		{
			return await _httpClient.GetFromJsonAsync<Categoriap>($"api/Categoria/ObtenerCategoriaPorID/{id}");
		}
		public async Task CreateCategorias(Categoriap categoria)
		{
			await _httpClient.PostAsJsonAsync("api/Categoria/CrearCategoria", categoria);
		}
		public async Task UpdateCategorias(int id, Categoriap categoria)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Categoria/{id}", categoria);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar las Categoria: {errorMessage}");
			}
		}
		public async Task DeleteCategorias(int id)
		{
			await _httpClient.DeleteAsync($"api/Categoria/EliminarCategoria/{id}");
		}
	}
}