using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.DTOs
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = null!;
        public int Stock { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool? Estado { get; set; }
    }
}
