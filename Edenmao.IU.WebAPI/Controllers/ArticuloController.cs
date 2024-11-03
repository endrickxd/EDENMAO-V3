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
    [Route("api/Articulos")]
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

        [HttpGet("ObtenerArticulos")]
        public async Task<ActionResult<IEnumerable<ArticuloDTO>>> GetAllArticulos()
        {
            var articulos = await _repository.GetAllAsync(a => a.IdCategoriaNav);
            var articulosDtos = _mapper.Map<IEnumerable<ArticuloDTO>>(articulos);
            return Ok(articulosDtos);
        }

        [HttpGet("ObtenerArticuloPorID/{id}")]
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
    }
}
