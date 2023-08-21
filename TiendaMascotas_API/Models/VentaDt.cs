using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class VentaDt
{
    public int IdVentaDt { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioU { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
