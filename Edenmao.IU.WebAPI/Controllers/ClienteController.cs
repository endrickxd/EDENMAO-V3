using AutoMapper;
using Edenmao.Core.DTOs.Articulo;
using Edenmao.Core.DTOs.Cliente;
using Edenmao.Core.Interfaces;
using Edenmao.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edenmao.IU.WebAPI.Controllers
{
    [Route("api/Clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository<Cliente> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteController> _logger;
        public ClienteController(IRepository<Cliente> repository, IMapper mapper, ILogger<ClienteController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("ObtenerClientes")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAllClientes()
        {
            var clientes = await _repository.GetAllAsync(a => !a.Eliminado && a.IdUsuarioNav != null && !a.IdUsuarioNav.Eliminado,
                a => a.IdUsuarioNav
            );

            var clientesDtos = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(clientesDtos);
        }

        [HttpGet("ObtenerClientePorID/{id}")]
        public async Task<ActionResult<ClienteDTO>> GetClienteById(int id)
        {
            var cliente = await _repository.GetByIdAsync(id, a => a.IdUsuarioNav);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDto = _mapper.Map<ClienteDTO>(cliente);
            return Ok(clienteDto);
        }

        [HttpPost("CrearCliente")]
        public async Task<ActionResult<ClienteDTO>> CreateCliente([FromBody] CUClienteDTO clientesDTO)
        {
            var cliente = _mapper.Map<Cliente>(clientesDTO);
            await _repository.AddAsync(cliente);
            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = clienteDTO.Id }, clienteDTO);
        }

        [HttpPut("EditarCliente/{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] CUClienteDTO clientesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteExistente = await _repository.GetByIdAsync(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(clientesDTO, clienteExistente);
            await _repository.UpdateAsync(clienteExistente);

            var clienteDTO = _mapper.Map<ClienteResponseDTO>(clienteExistente);
            return Ok(clienteDTO);
        }

        [HttpDelete("EliminarCliente/{id}")]
        public async Task<ActionResult<bool>> DeleteCliente(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            await _repository.DeleteByIdAsync(id);
            return Ok(cliente);
        }
    }
}
