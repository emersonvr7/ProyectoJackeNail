using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class DetalleCompra
{
    public int IdDetalle { get; set; }
    public int? IdCompra { get; set; }
    public int? IdProveedor { get; set; }
    public int? IdInsumo { get; set; }

    public string? ImagenInsumo { get; set; }

    public string? NombreInsumo { get; set; }

    public int? CantidadInsumo { get; set; }

    public int? UsosDisponibles { get; set; }

    public string? Categoria { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? TotalValorInsumos { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Insumo? IdInsumoNavigation { get; set; }
    public virtual Insumo? IdProveedorNavigation { get; set; }
}
