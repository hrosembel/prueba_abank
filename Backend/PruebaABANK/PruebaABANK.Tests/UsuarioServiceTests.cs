using Moq;
using PruebaABANK.BLL.Interfaces;
using PruebaABANK.BLL.Services;
using PruebaABANK.DAL.Interfaces;

namespace PruebaABANK.Tests
{
    public class UsuarioServiceTests
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var usuarioEsperado = new DAL.Entities.Usuario { 
                id = userId, Nombres = "John", Apellidos="Doe", Direccion="calle 123",
                Email="prueba@email.com", Password = "pass123",Telefono="12344321",FechaNacimiento = new DateTime(1900,2,3) };
            _repositoryMock.Setup(repo => repo.GetById(userId)).ReturnsAsync(usuarioEsperado);

            // Act
            var user = await _usuarioService.GetById(userId);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(usuarioEsperado.id, user.id);
            Assert.Equal(usuarioEsperado.Nombres, user.Nombres);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 2;
            _repositoryMock.Setup(repo => repo.GetById(userId)).ReturnsAsync((DAL.Entities.Usuario?)null);

            // Act
            var user = await _usuarioService.GetById(userId);

            // Assert
            Assert.Null(user);
        }
    }

}