using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public int IdTipoPago { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public bool? Estado { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual TipoPago IdTipoPagoNavigation { get; set; } = null!;

    public virtual ICollection<VentaDt> VentaDts { get; set; } = new List<VentaDt>();
}
