using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class TipoPago
{
    public int IdTipoPago { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
