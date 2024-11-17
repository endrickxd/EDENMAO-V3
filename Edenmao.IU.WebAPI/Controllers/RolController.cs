using AutoMapper;
using Edenmao.Core.DTOs.Rol;
using Edenmao.Core.Interfaces;
using Edenmao.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edenmao.IU.WebAPI.Controllers
{
    [Route("api/Roles")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRepository<Rol> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<RolController> _logger;
        public RolController(IRepository<Rol> repository, IMapper mapper, ILogger<RolController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("ObtenerRoles")]
        public async Task<ActionResult<IEnumerable<RolDTO>>> GetAllRoles()
        {
            var roles = await _repository.GetAllAsync();
            var rolesDtos = _mapper.Map<IEnumerable<RolDTO>>(roles);
            return Ok(rolesDtos);
        }

        [HttpGet("ObtenerRolPorID/{id}")]
        public async Task<ActionResult<RolDTO>> GetRolById(int id)
        {
            var rol = await _repository.GetByIdAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            var rolDto = _mapper.Map<RolDTO>(rol);
            return Ok(rolDto);
        }

        [HttpPost("CrearRol")]
        public async Task<ActionResult<RolDTO>> CreateRol([FromBody] CURolDTO rolesDTO)
        {
            var rol = _mapper.Map<Rol>(rolesDTO);
            await _repository.AddAsync(rol);
            var rolDTO = _mapper.Map<RolDTO>(rol);
            return CreatedAtAction(nameof(GetRolById), new { id = rolDTO.Id }, rolDTO);
        }

        [HttpPut("EditarRol/{id}")]
        public async Task<IActionResult> UpdateRol(int id, [FromBody] CURolDTO rolesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rolExistente = await _repository.GetByIdAsync(id);

            if (rolExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(rolesDTO, rolExistente);
            await _repository.UpdateAsync(rolExistente);

            var rolDTO = _mapper.Map<RolDTO>(rolExistente);
            return Ok(rolDTO);
        }

        [HttpDelete("EliminarRol/{id}")]
        public async Task<ActionResult<bool>> DeleteRol(int id)
        {
            var rol = await _repository.GetByIdAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            await _repository.DeleteByIdAsync(id);
            return Ok(rol);
        }
    }
}
