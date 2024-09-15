using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PruebaABANK.API.Controllers;
using PruebaABANK.BLL.Interfaces;
using PruebaABANK.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaABANK.Tests
{
    public class UsuarioControllerTests
    {
        private readonly Mock<IUsuarioService> _usuarioServiceMock;
        private readonly UsuarioController _userController;

        public UsuarioControllerTests()
        {
            _usuarioServiceMock = new Mock<IUsuarioService>();
            _userController = new UsuarioController(null, _usuarioServiceMock.Object);
        }

        [Fact]
        public async Task GetUser_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new BLL.Models.UsuarioLecturaDto { id = userId,
                Nombres = "John",
                Apellidos = "Doe",
                Direccion = "calle 123",
                Email = "prueba@email.com",
                Telefono = "12344321",
                FechaNacimiento = new DateTime(1900, 2, 3)
            };
            _usuarioServiceMock.Setup(service => service.GetById(userId)).ReturnsAsync(expectedUser);

            // Act
            var result = await _userController.GetById(userId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var user = Assert.IsType<UsuarioLecturaDto>(result.Value);
            Assert.Equal(expectedUser.id, user.id);
            Assert.Equal(expectedUser.Nombres, user.Nombres);
        }

        [Fact]
        public async Task GetUser_ReturnsNotFoundResult_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 2;
            _usuarioServiceMock.Setup(service => service.GetById(userId)).ReturnsAsync((UsuarioLecturaDto?)null);

            // Act
            var result = await _userController.GetById(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
