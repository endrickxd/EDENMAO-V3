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
    public class RolRepositoryTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly Mock<DbSet<Rol>> _mockDbSet;
        private readonly RolRepository _repository;

        public RolRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _mockDbSet = new Mock<DbSet<Rol>>();

            // Configura el DbSet simulado para que devuelva datos cuando sea necesario
            _mockContext.Setup(c => c.Set<Rol>()).Returns(_mockDbSet.Object);
            _repository = new RolRepository(_mockContext.Object);
        }

        // Prueba para AddAsync
        [Fact]
        public async Task AddAsync_ShouldAddRol()
        {
            // Arrange
            var rol = new Rol { Id = 1, Nombre = "Admin", Descripcion = "Administrador del sistema" };

            // Act
            await _repository.AddAsync(rol);

            // Assert
            _mockDbSet.Verify(m => m.Add(It.Is<Rol>(r => r == rol)), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        // Prueba para DeleteByIdAsync
        [Fact]
        public async Task DeleteByIdAsync_ShouldMarkRolAsEliminado()
        {
            // Arrange
            var rol = new Rol { Id = 1, Nombre = "Admin", Descripcion = "Administrador del sistema" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(rol);

            // Act
            await _repository.DeleteByIdAsync(1);

            // Assert
            rol.Eliminado.Should().BeTrue();
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}
