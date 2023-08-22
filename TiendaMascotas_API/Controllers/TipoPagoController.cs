using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaMascotas_API.Repositories;

namespace TiendaMascotas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagoController : ControllerBase
    {
        private readonly TipoPagoRepository _tipoPagoRepository;

        public TipoPagoController(TipoPagoRepository tipoPagoRepository)
        {
            _tipoPagoRepository = tipoPagoRepository;
        }

        [HttpGet("listarTipoPago")]
        public async Task<IActionResult> GetTipoPago()
        {
            try
            {
                var listTipoPago = await _tipoPagoRepository.getTipoPago();
                return Ok(listTipoPago);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
