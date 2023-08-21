using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
