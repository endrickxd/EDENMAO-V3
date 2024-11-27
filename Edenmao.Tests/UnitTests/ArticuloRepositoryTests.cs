using Edenmao.Domain.Entities;
using Edenmao.Infrastructure.Data;
using Edenmao.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Tests.UnitTests
{
    public class ArticuloRepositoryTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly Mock<DbSet<Articulo>> _mockDbSet;
        private readonly ArticuloRepository _repository;

        public ArticuloRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _mockDbSet = new Mock<DbSet<Articulo>>();

            // Configura el DbSet simulado para que devuelva datos cuando sea necesario
            _mockContext.Setup(c => c.Set<Articulo>()).Returns(_mockDbSet.Object);
            _repository = new ArticuloRepository(_mockContext.Object);
        }

        [Fact]
        public async Task AddAsync_DebeAgregarArticulo()
        {
            // Arrange
            var articulo = new Articulo { Id = 1, Nombre = "Articulo 1", Precio = 100 };

            // Act
            await _repository.AddAsync(articulo);

            // Assert
            _mockDbSet.Verify(m => m.Add(It.Is<Articulo>(a => a == articulo)), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task DeleteByIdAsync_DebeMarcarArticuloComoEliminado()
        {
            // Arrange
            var articulo = new Articulo { Id = 1, Nombre = "Articulo 1", Precio = 100 };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(articulo);

            // Act
            await _repository.DeleteByIdAsync(1);

            // Assert
            articulo.Eliminado.Should().BeTrue();
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}
