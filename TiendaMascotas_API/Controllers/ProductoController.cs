using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaMascotas_API.Repositories;

namespace TiendaMascotas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoController(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet("listarProductos")]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var listProductos = await _productoRepository.getProductos();
                return Ok(listProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
