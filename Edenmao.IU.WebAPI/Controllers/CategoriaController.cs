using AutoMapper;
using Edenmao.Core.DTOs.Categoria;
using Edenmao.Core.DTOs.Rol;
using Edenmao.Core.Interfaces;
using Edenmao.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edenmao.IU.WebAPI.Controllers
{
    [Route("api/Categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriaController> _logger;
        public CategoriaController(IRepository<Categoria> repository, IMapper mapper, ILogger<CategoriaController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("ObtenerCategorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAllCategorias()
        {
            var categorias = await _repository.GetAllAsync();
            var categoriasDtos = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return Ok(categoriasDtos);
        }

        [HttpGet("ObtenerCategoriaPorID/{id}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoriaById(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return Ok(categoriaDto);
        }

        [HttpPost("CrearCategoria")]
        public async Task<ActionResult<CategoriaDTO>> CreateCategoria([FromBody] CUCategoriaDTO categoriasDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriasDTO);
            await _repository.AddAsync(categoria);
            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpPut("EditarCategoria/{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CUCategoriaDTO categoriasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaExistente = await _repository.GetByIdAsync(id);

            if (categoriaExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(categoriasDTO, categoriaExistente);
            await _repository.UpdateAsync(categoriaExistente);

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoriaExistente);
            return Ok(categoriaDTO);
        }

        [HttpDelete("EliminarCategoria/{id}")]
        public async Task<ActionResult<bool>> DeleteCategoria(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            await _repository.DeleteByIdAsync(id);
            return Ok(categoria);
        }
    }
}
