namespace TiendaMascotas_API.DTOs
{
    public class RolDTO
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Estado { get; set; }
    }
}
