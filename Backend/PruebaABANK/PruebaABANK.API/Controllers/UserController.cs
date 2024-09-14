using Microsoft.AspNetCore.Mvc;
using PruebaABANK.API.Models;
using PruebaABANK.API.Repository;
using System.Net;

namespace PruebaABANK.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUsuarioRepository _usuarioRepository;

        public UserController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _usuarioRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Usuario? usuario = await _usuarioRepository.GetById(id);
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
        public async Task<IActionResult> Add([FromBody] Usuario usuario)
        {
            try
            {
                int usuarioId = await _usuarioRepository.Add(usuario);
                usuario.id = usuarioId;
                return StatusCode(StatusCodes.Status201Created,usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Usuario usuario)
        {
            try
            {
                bool isUpdated = await _usuarioRepository.Edit(usuario);
                if (isUpdated)
                {
                    return Ok(usuario);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Usuario usuario = await _usuarioRepository.GetById(id);

                bool isDeleted = await _usuarioRepository.Delete(id);
                if (isDeleted)
                {
                    return Ok(usuario);
                }
                return BadRequest("Eliminación de usuario fallida.");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }
        }
    }
}
