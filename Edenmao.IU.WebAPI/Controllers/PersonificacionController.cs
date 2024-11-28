using AutoMapper;
using Edenmao.Core.DTOs.Personificacion;
using Edenmao.Core.DTOs.Rol;
using Edenmao.Core.Interfaces;
using Edenmao.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edenmao.IU.WebAPI.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class PersonificacionController : ControllerBase
    {
        private readonly IRepository<Personificacion> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonificacionController> _logger;
        public PersonificacionController(IRepository<Personificacion> repository, IMapper mapper, ILogger<PersonificacionController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObtenerPersonificaciones")]
        public async Task<ActionResult<IEnumerable<PersonificacionDTO>>> GetAllPersonificaciones()
        {
            var personificaciones = await _repository.GetAllAsync();
            var personificacionesDtos = _mapper.Map<IEnumerable<PersonificacionDTO>>(personificaciones);
            return Ok(personificacionesDtos);
        }

        [HttpGet]
        [Route("ObtenerPersonificacionPorID/{id}")]
        public async Task<ActionResult<PersonificacionDTO>> GetPersonificacionById(int id)
        {
            var personificacion = await _repository.GetByIdAsync(id);

            if (personificacion == null)
            {
                return NotFound();
            }

            var personificacionDto = _mapper.Map<PersonificacionDTO>(personificacion);
            return Ok(personificacionDto);
        }

        [HttpPost("CrearPersonificacion")]
        public async Task<ActionResult<PersonificacionDTO>> CreatePersonificacion([FromBody] CUPersonificacionDTO personificacionesDTO)
        {
            var personificacion = _mapper.Map<Personificacion>(personificacionesDTO);
            await _repository.AddAsync(personificacion);
            var personificacionDTO = _mapper.Map<PersonificacionDTO>(personificacion);
            return CreatedAtAction(nameof(GetPersonificacionById), new { id = personificacionDTO.Id }, personificacionDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonificacion(int id, [FromBody] CUPersonificacionDTO personificacionesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personificacionExistente = await _repository.GetByIdAsync(id);

            if (personificacionExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(personificacionesDTO, personificacionExistente);
            await _repository.UpdateAsync(personificacionExistente);

            var personificacionDTO = _mapper.Map<PersonificacionDTO>(personificacionExistente);
            return Ok(personificacionDTO);
        }

        [HttpDelete("EliminarPersonificacion/{id}")]
        public async Task<ActionResult<bool>> DeletePersonificacion(int id)
        {
            var personificacion = await _repository.GetByIdAsync(id);

            if (personificacion == null)
            {
                return NotFound();
            }

            await _repository.DeleteByIdAsync(id);
            return Ok(personificacion);
        }
    }
}
