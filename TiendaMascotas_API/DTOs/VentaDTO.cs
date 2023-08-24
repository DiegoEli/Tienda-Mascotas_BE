﻿using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.DTOs
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }

        public int IdCliente { get; set; }

        public string NombreCliente { get; set; } = null!;

        public decimal Subtotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }

        public bool? Estado { get; set; }

        public DateTime CreadoDate { get; set; }

        public virtual ICollection<VentaDt> VentaDts { get; set; }
    }
}
