using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Models;
using TiendaMascotas_API.Repositories;

namespace TiendaMascotas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaController(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("listarCategorias")]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var listCategorias = await _categoriaRepository.getCategorias();
                return Ok(listCategorias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPost("agregarCategoria")]
        //public async Task<ActionResult> PostCategorias(Categoria categoria)
        //{
        //    try
        //    {
        //        categoria.CreadoDate = DateTime.Now;
        //        await _categoriaRepository.postCategorias(categoria);
        //        return CreatedAtAction("Get", new { id = categoria.IdCategoria }, categoria);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }

        //}

        [HttpPost("agregarCategoria")]
        public async Task<ActionResult> PostCategorias(Categoria categoria)
        {
            try
            {
                categoria.CreadoDate = DateTime.Now;
                await _categoriaRepository.postCategorias(categoria);
                return Ok(categoria); // Devuelve la categoría creada
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
