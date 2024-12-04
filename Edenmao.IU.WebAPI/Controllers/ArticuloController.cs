using AutoMapper;
using Edenmao.Core.DTOs.Articulo;
using Edenmao.Core.DTOs.Categoria;
using Edenmao.Core.DTOs.Rol;
using Edenmao.Core.Interfaces;
using Edenmao.Domain.Entities;
using Edenmao.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edenmao.IU.WebAPI.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]

	public class ArticuloController : ControllerBase
    {
        private readonly IRepository<Articulo> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ArticuloController> _logger;
        public ArticuloController(IRepository<Articulo> repository, IMapper mapper, ILogger<ArticuloController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

		[HttpGet]
		[Route("ObtenerArticulos")]
		public async Task<ActionResult<IEnumerable<ArticuloDTO>>> GetAllArticulos()
        {
            var articulos = await _repository.GetAllAsync(a => !a.Eliminado && a.IdCategoriaNav != null && !a.IdCategoriaNav.Eliminado,
                a => a.IdCategoriaNav 
            );

            var articulosDtos = _mapper.Map<IEnumerable<ArticuloDTO>>(articulos);
            return Ok(articulosDtos);
        }

		[HttpGet]
		[Route("ObtenerArticuloPorId/{id}")]
		public async Task<ActionResult<ArticuloDTO>> GetArticuloById(int id)
        {
            var articulo = await _repository.GetByIdAsync(id, a => a.IdCategoriaNav);

            if (articulo == null)
            {
                return NotFound();
            }

            var articuloDto = _mapper.Map<ArticuloDTO>(articulo);
            return Ok(articuloDto);
        }

        [HttpPost("CrearArticulo")]
        public async Task<ActionResult<ArticuloDTO>> CreateArticulo([FromBody] CUArticuloDTO articulosDTO)
        {
            var articulo = _mapper.Map<Articulo>(articulosDTO);
            await _repository.AddAsync(articulo);
            var articuloDTO = _mapper.Map<ArticuloDTO>(articulo);
            return CreatedAtAction(nameof(GetArticuloById), new { id = articuloDTO.Id }, articuloDTO);
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateArticulo(int id, [FromBody] CUArticuloDTO articulosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articuloExistente = await _repository.GetByIdAsync(id);

            if (articuloExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(articulosDTO, articuloExistente);
            await _repository.UpdateAsync(articuloExistente);

            var articuloDTO = _mapper.Map<ArticuloResponseDTO>(articuloExistente);
            return Ok(articuloDTO);
        }

		[HttpDelete("EliminarArticulo/{id}")]
		public async Task<ActionResult<bool>> DeleteArticulo(int id)
        {
            var articulo = await _repository.GetByIdAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            await _repository.DeleteByIdAsync(id);
            return Ok(articulo);
        }
    }
}
