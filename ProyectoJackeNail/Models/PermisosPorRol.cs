using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class PermisosPorRol
{
    public int? RolId { get; set; }

    public int? PermisoId { get; set; }

    public virtual Permiso? Permiso { get; set; }

    public virtual Role? Rol { get; set; }
}
