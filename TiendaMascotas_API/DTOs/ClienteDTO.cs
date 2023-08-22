using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.DTOs
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = null!;

        public string Identificacion { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public int IdEstadoCivil { get; set; }

        public string NombreEstadoCivil { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int IdUsuario { get; set; }

        public string Password { get; set; } = null!;

        public bool? Estado { get; set; }


    }
}
