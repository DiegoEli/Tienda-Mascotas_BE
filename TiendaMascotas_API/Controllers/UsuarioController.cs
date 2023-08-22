﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}