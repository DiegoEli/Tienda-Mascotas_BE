using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int IdRol { get; set; }

    public bool? Estado { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
