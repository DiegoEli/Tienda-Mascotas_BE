using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int IdEstadoCivil { get; set; }

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int IdUsuario { get; set; }

    public bool? Estado { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual EstadoCivil IdEstadoCivilNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
