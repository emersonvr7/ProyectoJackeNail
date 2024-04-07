using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Compra
{
    public int IdCompra { get; set; }
    public DateTime? FechaCompra { get; set; }
    public decimal? DescuentoCompra { get; set; }

    public decimal? SubtotalCompra { get; set; }

    public decimal? IvaCompra { get; set; }

    public string? EstadoCompra { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
}
