using AutoMapper;
using Edenmao.Core.DTOs.Articulo;
using Edenmao.Core.DTOs.Usuario;
using Edenmao.Core.Interfaces;
using Edenmao.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edenmao.IU.WebAPI.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(IRepository<Usuario> repository, IMapper mapper, ILogger<UsuarioController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAllUsuarios()
        {
            var usuarios = await _repository.GetAllAsync(a => !a.Eliminado && a.IdRolNav != null && !a.IdRolNav.Eliminado,
                a => a.IdRolNav
            );

            var usuariosDtos = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDtos);
        }

        [HttpGet]
        [Route("ObtenerUsuarioPorID/{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioById(int id)
        {
            var usuario = await _repository.GetByIdAsync(id, a => a.IdRolNav);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);
            return Ok(usuarioDto);
        }

        [HttpPost("CrearUsuario")]
        public async Task<ActionResult<UsuarioDTO>> CreateUsuario([FromBody] CUUsuarioDTO usuariosDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuariosDTO);
            await _repository.AddAsync(usuario);
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuarioDTO.Id }, usuarioDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] CUUsuarioDTO usuariosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioExistente = await _repository.GetByIdAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(usuariosDTO, usuarioExistente);
            await _repository.UpdateAsync(usuarioExistente);

            var usuarioDTO = _mapper.Map<UsuarioResponseDTO>(usuarioExistente);
            return Ok(usuarioDTO);
        }

        [HttpDelete("EliminarUsuario/{id}")]
        public async Task<ActionResult<bool>> DeleteUsuario(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            await _repository.DeleteByIdAsync(id);
            return Ok(usuario);
        }
    }
}
