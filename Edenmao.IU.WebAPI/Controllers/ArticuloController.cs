﻿using AutoMapper;
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
            ////var articulos = await _repository.GetAllAsync(a => a.IdCategoriaNav);
            ////var articulosDtos = _mapper.Map<IEnumerable<ArticuloDTO>>(articulos);
            ////return Ok(articulosDtos);
            //// Obtiene los artículos no eliminados y carga la propiedad de navegación "IdCategoriaNav"
            //var articulos = await _repository.GetAllAsync(
            //    null,  // No hay predicado adicional
            //    a => a.IdCategoriaNav // Incluir la propiedad de navegación para cargar la categoría
            //);

            //var articulosDtos = _mapper.Map<IEnumerable<ArticuloDTO>>(articulos);
            //return Ok(articulosDtos);
            // Obtiene los artículos que no están eliminados y cuya categoría tampoco está eliminada
            var articulos = await _repository.GetAllAsync(
                a => !a.Eliminado && a.IdCategoriaNav != null && !a.IdCategoriaNav.Eliminado, // Filtra por artículos y categorías no eliminadas
                a => a.IdCategoriaNav // Incluye la categoría asociada
            );

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

        [HttpPost("CrearArticulo")]
        public async Task<ActionResult<ArticuloDTO>> CreateArticulo([FromBody] CUArticuloDTO articulosDTO)
        {
            var articulo = _mapper.Map<Articulo>(articulosDTO);
            await _repository.AddAsync(articulo);
            var articuloDTO = _mapper.Map<ArticuloDTO>(articulo);
            return CreatedAtAction(nameof(GetArticuloById), new { id = articuloDTO.Id }, articuloDTO);
        }

        [HttpPut("EditarArticulo/{id}")]
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