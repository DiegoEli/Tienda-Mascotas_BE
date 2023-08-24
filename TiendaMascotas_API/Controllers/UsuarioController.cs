using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Repositories;

namespace TiendaMascotas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("listarUsuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var listUsuarios = await _usuarioRepository.getUsuarios();
                return Ok(listUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("validarCredenciales")]
        public async Task<IActionResult> ValidarCredenciales([FromBody] UsuarioDTO user)
        {
            try
            {
                var usuario = await _usuarioRepository.validateCredentials(user.Email, user.Clave);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] ClienteDTO cliente)
        {
            try
            {
                var usuario = await _usuarioRepository.register(cliente);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("actualizarPass")]
        public async Task<IActionResult> ActualizarPassword([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var resp = await _usuarioRepository.resetPassword(usuario);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
