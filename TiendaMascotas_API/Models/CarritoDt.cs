using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class CarritoDt
{
    public int IdCarritoDt { get; set; }

    public int IdCarrito { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioU { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual Carrito IdCarritoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
