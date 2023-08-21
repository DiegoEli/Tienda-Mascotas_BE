using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdCategoria { get; set; }

    public int Stock { get; set; }

    public decimal PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public bool? Estado { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual ICollection<CarritoDt> CarritoDts { get; set; } = new List<CarritoDt>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<ProductoMascotum> ProductoMascota { get; set; } = new List<ProductoMascotum>();

    public virtual ICollection<VentaDt> VentaDts { get; set; } = new List<VentaDt>();
}
