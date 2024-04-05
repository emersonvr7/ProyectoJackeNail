using System;
using System.Collections.Generic;

namespace ProyectoJackeNail.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidoUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Telefono { get; set; }

    public int? RolId { get; set; }

    public virtual Role? Rol { get; set; }
}
