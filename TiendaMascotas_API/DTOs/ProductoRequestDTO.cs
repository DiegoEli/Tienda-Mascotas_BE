using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Models;

public class ProductoRequestDTO
{
    public ProductoDTO Producto { get; set; }
    public CarritoDtDTO Carrito { get; set; }
    public ProductoMascota ProductoMascota { get; set; }
    public VentaDt VentaDt { get; set; }
}
