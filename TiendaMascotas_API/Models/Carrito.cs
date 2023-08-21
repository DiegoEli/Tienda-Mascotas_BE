using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class Carrito
{
    public int IdCarrito { get; set; }

    public int IdCliente { get; set; }

    public int DiasCaducidad { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public bool? Estado { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual ICollection<CarritoDt> CarritoDts { get; set; } = new List<CarritoDt>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
