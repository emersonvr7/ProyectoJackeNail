using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int? IdProveedor { get; set; }

    public DateTime? FechaCompra { get; set; }

    public decimal? DescuentoCompra { get; set; }

    public decimal? SubtotalCompra { get; set; }

    public decimal? IvaCompra { get; set; }

    public int? EstadoCompra { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
