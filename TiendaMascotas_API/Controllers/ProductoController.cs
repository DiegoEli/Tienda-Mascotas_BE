using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Models;
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

        [HttpGet("obtenerProducto/{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            try
            {
                var producto = await _productoRepository.getProducto(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("agregarProductos")]
        public async Task<IActionResult> PostProductos([FromBody] ProductoDTO ProductoDTO)
        {
            try
            {
                var productoCreado = await _productoRepository.postProducto(ProductoDTO);
                return Ok(productoCreado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
