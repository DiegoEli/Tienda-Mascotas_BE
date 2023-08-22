using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaMascotas_API.Repositories;

namespace TiendaMascotas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCivilController : ControllerBase
    {
        private readonly EstadoCivilRepository _estadoCivilRepository;

        public EstadoCivilController(EstadoCivilRepository estadoCivilRepository)
        {
            _estadoCivilRepository = estadoCivilRepository;
        }

        [HttpGet("listarEstadoCivil")]
        public async Task<IActionResult> GetEstadoCivil()
        {
            try
            {
                var listEstadoCivil = await _estadoCivilRepository.getEstadoCivil();
                return Ok(listEstadoCivil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
