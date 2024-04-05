using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public int? IdServicio { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdCliente { get; set; }

    public decimal TotalVenta { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Empleado? IdClienteNavigation { get; set; }

    public virtual Cliente? IdEmpleadoNavigation { get; set; }

    public virtual Service? IdServicioNavigation { get; set; }
}
