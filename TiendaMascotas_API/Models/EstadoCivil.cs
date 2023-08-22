using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class EstadoCivil
{
    public int IdEstadoCivil { get; set; }
    public string Nombre { get; set; } = null!;
    public bool? Estado { get; set; }
    public DateTime CreadoDate { get; set; }
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
