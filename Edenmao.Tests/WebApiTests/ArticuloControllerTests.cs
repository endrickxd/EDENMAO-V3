using AutoMapper;
using Edenmao.Core.DTOs.Articulo;
using Edenmao.Core.Interfaces;
using Edenmao.Domain.Entities;
using Edenmao.IU.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Tests.WebApiTests
{
    public class ArticuloControllerTests
    {
        public class ArticulosControllerTests
        {
            private readonly Mock<IRepository<Articulo>> _repositoryMock;
            private readonly Mock<IMapper> _mapperMock;
            private readonly Mock<ILogger<ArticuloController>> _loggerMock;
            private readonly ArticuloController _controller;

            public ArticulosControllerTests()
            {
                _repositoryMock = new Mock<IRepository<Articulo>>();
                _mapperMock = new Mock<IMapper>();
                _loggerMock = new Mock<ILogger<ArticuloController>>();
                _controller = new ArticuloController(_repositoryMock.Object, _mapperMock.Object, _loggerMock.Object);
            }

            [Fact]
            public async Task GetAllArticulos_ReturnsOkResult_WithArticuloDTOs()
            {
                // Arrange
                var articulos = new List<Articulo>
            {
                new Articulo { Id = 1, Nombre = "Articulo1", IdCategoriaNav = new Categoria { Nombre = "Categoria1" } },
                new Articulo { Id = 2, Nombre = "Articulo2", IdCategoriaNav = new Categoria { Nombre = "Categoria2" } }
            };

                var articuloDTOs = articulos.Select(a => new ArticuloDTO
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    NombreCategoria = a.IdCategoriaNav.Nombre
                }).ToList();

                _repositoryMock
                    .Setup(repo => repo.GetAllAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Articulo, bool>>>(), It.IsAny<System.Linq.Expressions.Expression<System.Func<Articulo, object>>[]>()))
                    .ReturnsAsync(articulos);

                _mapperMock
                    .Setup(mapper => mapper.Map<IEnumerable<ArticuloDTO>>(It.IsAny<IEnumerable<Articulo>>()))
                    .Returns(articuloDTOs);

                // Act
                var result = await _controller.GetAllArticulos();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsAssignableFrom<IEnumerable<ArticuloDTO>>(okResult.Value);
                Assert.Equal(2, returnValue.Count());
            }

            [Fact]
            public async Task GetArticuloById_ArticuloExists_ReturnsOkResult()
            {
                // Arrange
                var articulo = new Articulo { Id = 1, Nombre = "Articulo1", IdCategoriaNav = new Categoria { Nombre = "Categoria1" } };
                var articuloDTO = new ArticuloDTO { Id = 1, Nombre = "Articulo1", NombreCategoria = "Categoria1" };

                _repositoryMock
                    .Setup(repo => repo.GetByIdAsync(1, It.IsAny<System.Linq.Expressions.Expression<System.Func<Articulo, object>>>()))
                    .ReturnsAsync(articulo);

                _mapperMock
                    .Setup(mapper => mapper.Map<ArticuloDTO>(articulo))
                    .Returns(articuloDTO);

                // Act
                var result = await _controller.GetArticuloById(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<ArticuloDTO>(okResult.Value);
                Assert.Equal(1, returnValue.Id);
                Assert.Equal("Articulo1", returnValue.Nombre);
            }

            [Fact]
            public async Task GetArticuloById_ArticuloDoesNotExist_ReturnsNotFound()
            {
                // Arrange
                _repositoryMock
                    .Setup(repo => repo.GetByIdAsync(1, It.IsAny<System.Linq.Expressions.Expression<System.Func<Articulo, object>>>()))
                    .ReturnsAsync((Articulo)null);

                // Act
                var result = await _controller.GetArticuloById(1);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }

            [Fact]
            public async Task CreateArticulo_ValidData_ReturnsCreatedResult()
            {
                // Arrange
                var cuArticuloDTO = new CUArticuloDTO { Nombre = "ArticuloNuevo", IdCategoria = 1, Precio = 100, Stock = 10 };
                var articulo = new Articulo { Id = 1, Nombre = "ArticuloNuevo", IdCategoria = 1, Precio = 100, Stock = 10 };
                var articuloDTO = new ArticuloDTO { Id = 1, Nombre = "ArticuloNuevo", IdCategoria = 1 };

                _mapperMock
                    .Setup(mapper => mapper.Map<Articulo>(cuArticuloDTO))
                    .Returns(articulo);

                _mapperMock
                    .Setup(mapper => mapper.Map<ArticuloDTO>(articulo))
                    .Returns(articuloDTO);

                _repositoryMock
                    .Setup(repo => repo.AddAsync(articulo))
                    .Returns(Task.CompletedTask);

                // Act
                var result = await _controller.CreateArticulo(cuArticuloDTO);

                // Assert
                var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
                var returnValue = Assert.IsType<ArticuloDTO>(createdResult.Value);
                Assert.Equal("ArticuloNuevo", returnValue.Nombre);
            }

            [Fact]
            public async Task UpdateArticulo_ArticuloDoesNotExist_ReturnsNotFound()
            {
                // Arrange
                _repositoryMock
                    .Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync((Articulo)null);

                var cuArticuloDTO = new CUArticuloDTO { Nombre = "ArticuloActualizado", IdCategoria = 1, Precio = 120, Stock = 15 };

                // Act
                var result = await _controller.UpdateArticulo(1, cuArticuloDTO);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public async Task DeleteArticulo_ArticuloExists_ReturnsOkResult()
            {
                // Arrange
                var articulo = new Articulo { Id = 1, Nombre = "ArticuloAEliminar" };

                _repositoryMock
                    .Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(articulo);

                _repositoryMock
                    .Setup(repo => repo.DeleteByIdAsync(1))
                    .ReturnsAsync(true);

                // Act
                var result = await _controller.DeleteArticulo(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                Assert.Equal(articulo, okResult.Value);
            }

            [Fact]
            public async Task DeleteArticulo_ArticuloDoesNotExist_ReturnsNotFound()
            {
                // Arrange
                _repositoryMock
                    .Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync((Articulo)null);

                // Act
                var result = await _controller.DeleteArticulo(1);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }
    }
}
