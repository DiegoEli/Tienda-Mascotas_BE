using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = null!;
        public bool? Estado { get; set; }
        public DateTime CreadoDate { get; set; }
    }
}
