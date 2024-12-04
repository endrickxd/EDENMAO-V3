using Edenmao.Core.DTOs.Articulo;
using Edenmao.Core.DTOs.Categoria;
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
        public async Task<IEnumerable<CategoriaDTO>> GetAllCategorias()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CategoriaDTO>>("api/Categorias");
        }
        public async Task<CategoriaDTO> GetCategoriasById(int id)
        {
            return await _httpClient.GetFromJsonAsync<CategoriaDTO>($"api/Categorias/{id}");
        }
        public async Task CreateCategorias(CategoriaDTO categoria)
        {
            await _httpClient.PostAsJsonAsync("api/Categorias", categoria);
        }
        public async Task UpdateCategorias(int id, CategoriaDTO categoria)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Categorias/{id}", categoria);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar las Categorias: {errorMessage}");
            }
        }
        public async Task DeleteCategorias(int id)
        {
            await _httpClient.DeleteAsync($"api/Categorias/{id}");
        }
    }
}
