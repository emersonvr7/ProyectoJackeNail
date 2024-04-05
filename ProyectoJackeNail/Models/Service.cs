using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Service
{
    public int Id { get; set; }

    public string? Servicio { get; set; }

    public string? Precio { get; set; }

    public string? Tiempo { get; set; }

    public string? ImgServicio { get; set; }

    public string? NivelUña { get; set; }

    public string? EstadoServicio { get; set; }

    public virtual ICollection<Agendamiento> Agendamientos { get; set; } = new List<Agendamiento>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
