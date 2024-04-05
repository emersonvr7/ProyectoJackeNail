using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Documento { get; set; }

    public int? RolId { get; set; }

    public virtual ICollection<Agendamiento> Agendamientos { get; set; } = new List<Agendamiento>();

    public virtual Role? Rol { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
