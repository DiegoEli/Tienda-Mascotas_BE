using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.DTOs
{
    public class CarritoDtDTO
    {
        public int IdCarrito { get; set; }
        public int IdProducto { get; set; }
        public string DescripcionProducto { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioU { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public DateTime CreadoDate { get; set; }
    }
}
