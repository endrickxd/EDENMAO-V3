using Edenmao.UI.Frontend.Modals;
using System.Net.Http.Json;

namespace Edenmao.UI.Frontend.Services
{
	//[Route("api/Clientes")]
	public class ClienteServices
	{
		private readonly HttpClient _httpClient;
		public ClienteServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<Clientesp>> GetAllClientes()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Clientesp>>("api/Cliente/ObtenerClientes");
		}
		public async Task<Clientesp> GetClientesById(int id)
		{
			return await _httpClient.GetFromJsonAsync<Clientesp>($"api/Cliente/ObtenerClientePorID/{id}");
		}
		public async Task CreateClientes(Clientesp clientes)
		{
			await _httpClient.PostAsJsonAsync("api/Cliente/CrearCliente", clientes);
		}
		public async Task UpdateClientes(int id, Clientesp clientes)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Cliente/{id}", clientes);
			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				throw new Exception($"Error al actualizar las Clientes: {errorMessage}");
			}
		}
		public async Task DeleteClientes(int id)
		{
			await _httpClient.DeleteAsync($"api/Cliente/EliminarCliente/{id}");
		}
	}
}