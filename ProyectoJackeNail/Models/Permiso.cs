using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string NombrePermiso { get; set; } = null!;

    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
}
