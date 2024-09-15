using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

using PruebaABANK.BLL.Models;
using PruebaABANK.BLL.Interfaces;

namespace PruebaABANK.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration , IUsuarioService usuarioService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [Route("auth/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {

                UsuarioDto? usuario = await _usuarioService.GetByCredentials(model);

                if (usuario != null) {
                    // Validar usuario 
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, model.Email)
                        // Añadir más claims según sea necesario
                    };

                    var key = _configuration["Jwt:Key"];
                    if (key == null)
                        return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                            SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new
                    {
                        user = usuario,
                        access_token = new JwtSecurityTokenHandler().WriteToken(token),
                        token_type = "bearer"
                    });                   
                }
                return Unauthorized("Usuario no autorizado");
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _usuarioService.GetAll());
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                UsuarioLecturaDto? usuario = await _usuarioService.GetById(id);
                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] UsuarioEdicionDto usuario)
        {
            try
            {
                int usuarioId = await _usuarioService.Add(usuario);
                return StatusCode(StatusCodes.Status201Created,new UsuarioDto
                {
                    id = usuarioId,
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    FechaNacimiento = usuario.FechaNacimiento,
                    Direccion = usuario.Direccion,
                    Password = usuario.Password,
                    Telefono = usuario.Telefono,
                    Email = usuario.Email
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [FromBody]UsuarioEdicionDto usuario)
        {
            try
            {
                bool isUpdated = await _usuarioService.Edit(id, usuario);
                if (isUpdated)
                {
                    return Ok(usuario);
                }
                return BadRequest();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                UsuarioLecturaDto? usuario = await _usuarioService.GetById(id);

                bool isDeleted = await _usuarioService.Delete(id);
                if (isDeleted)
                {
                    return Ok(usuario);
                }
                return BadRequest("Eliminación de usuario fallida.");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }
    }
}
