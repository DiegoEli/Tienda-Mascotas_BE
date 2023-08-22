namespace TiendaMascotas_API.DTOs
{
    public class EstadoCivilDTO
    {
        public int IdEstadoCivil { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Estado { get; set; }
    }
}
