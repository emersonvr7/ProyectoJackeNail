using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? NombreProveedor { get; set; }

    public string? CorreoProveedor { get; set; }

    public string? TelefonoProveedor { get; set; }

    public string? DireccionProveedor { get; set; }

    public string? EmpresaProveedor { get; set; }

    public string? EstadoProveedor { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
