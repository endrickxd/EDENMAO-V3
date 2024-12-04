using Edenmao.Core.DTOs.Cliente;
using Edenmao.Core.DTOs.Usuario;
using Edenmao.Domain.Entities;
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
        public async Task<IEnumerable<ClienteDTO>> GetAllClientes()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClienteDTO>>("api/Clientes");
        }
        public async Task<ClienteDTO> GetClientesById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ClienteDTO>($"api/Clientes/{id}");
        }
        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuario()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioDTO>>("api/Usuarios");
        }
        public async Task CreateClientes(ClienteDTO clientes)
        {
            await _httpClient.PostAsJsonAsync("api/Clientes", clientes);
        }
        public async Task UpdateClientes(int id, ClienteDTO clientes)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Clientes/{id}", clientes);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar las Clientes: {errorMessage}");
            }
        }
        public async Task DeleteClientes(int id)
        {
            await _httpClient.DeleteAsync($"api/Clientes/{id}");
        }
    }
}
