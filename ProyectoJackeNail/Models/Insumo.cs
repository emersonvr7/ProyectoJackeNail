﻿using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Insumo
{
    public int IdInsumo { get; set; }

    public string? ImagenInsumo { get; set; }

    public string? NombreInsumo { get; set; }

    public int? CantidadInsumo { get; set; }

    public int? UsosDisponibles { get; set; }

    public string? EstadoInsumo { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
