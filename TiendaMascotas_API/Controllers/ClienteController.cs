using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Repositories;

namespace TiendaMascotas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteController(ClienteRepository clienteRepository) {
            _clienteRepository = clienteRepository;

        }

        [HttpGet("listarClientes")]
        public async Task<IActionResult> GetCliente()
        {
            try
            {
                var listClientes = await _clienteRepository.getClientes();
                return Ok(listClientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("actualizarCliente")]
        public async Task<IActionResult> ActualizarCliente([FromBody] ClienteDTO cliente)
        {
            try
            {
                var resp = await _clienteRepository.updateCliente(cliente);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
