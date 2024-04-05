using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class DetalleVentum
{
    public int Id { get; set; }

    public int IdVenta { get; set; }

    public int IdInsumo { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
