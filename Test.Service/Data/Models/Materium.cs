using System;
using System.Collections.Generic;

namespace Test.Service.Data.Models;

public partial class Materium
{
    public int Id { get; set; }

    public int? IdColegio { get; set; }

    public string? Nombre { get; set; }

    public string? Area { get; set; }

    public int? NumeroEstudiantes { get; set; }

    public string? DocenteAsignado { get; set; }

    public string? Curso { get; set; }

    public string? Paralelo { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; } = new List<Calificacione>();

    public virtual Colegio? IdColegioNavigation { get; set; }
}
