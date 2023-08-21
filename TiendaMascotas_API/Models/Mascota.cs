using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class Mascota
{
    public int IdMascota { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual ICollection<ProductoMascotum> ProductoMascota { get; set; } = new List<ProductoMascotum>();
}
