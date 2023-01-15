using System;
using System.Collections.Generic;

namespace Test.Service.Data.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; } = new List<Calificacione>();
}
