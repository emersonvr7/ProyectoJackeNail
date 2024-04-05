using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Agendamiento
{
    public int Id { get; set; }

    public int? ClienteId { get; set; }

    public int? ServicioId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateOnly? FechaAgenda { get; set; }

    public string? EstadoAgenda { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Service? Servicio { get; set; }
}
