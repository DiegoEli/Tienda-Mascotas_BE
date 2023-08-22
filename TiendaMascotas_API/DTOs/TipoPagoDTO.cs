namespace TiendaMascotas_API.DTOs
{
    public class TipoPagoDTO
    {
        public int IdTipoPago { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }
    }
}
